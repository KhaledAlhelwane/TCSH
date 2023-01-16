// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TCSH.Models;

namespace TCSH.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

       
        public string Username { get; set; }

       
        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

       
        public class InputModel
        {
            [Required]
            [StringLength(10,ErrorMessage ="يجب ان لا يتجاوز الاسم أكثر من 10 محرف")]
            public string FirstName { get; set; }
            [Required]
            [StringLength(10, ErrorMessage = "يجب ان لا تتجاوز الكنية أكثر من 10 محرف")]
            public string SecoundName { get; set; }
            [Required]
            public string Locstion { get; set; }
           
            public byte[] ProfilePicture { get; set; }
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName=user.FirstName,
                SecoundName=user.SecoundName,
                Locstion=user.Locstion,
                ProfilePicture=user.ProfilePicture

                
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            user.PhoneNumber = Input.PhoneNumber;
            user.FirstName = Input.FirstName;
            user.SecoundName = Input.SecoundName;
            user.PhoneNumber = Input.PhoneNumber;
            user.Locstion = Input.Locstion;
            //if (Input.PhoneNumber != phoneNumber)
            //{
            //    //var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                var setResult=await _userManager.UpdateAsync(user);
                if (!setResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            //}
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files.FirstOrDefault();
                //check file size and extension
                using (var datestream = new MemoryStream())
                {
                    await file.CopyToAsync(datestream);
                    user.ProfilePicture= datestream.ToArray();
                }
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
