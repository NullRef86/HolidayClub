namespace HolidayClub.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Data;
    using Enums;
    using Models;

    [Authorize]
    public class ParentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParentController (ApplicationDbContext context)
        {
            _context = context;
        }

        public ViewResult ContactDetails()
        {
            var contactDetails = GetContactDetails();

            var viewModel = new ContactDetailsViewModel
            {
                Title = contactDetails.Title,
                Forename = contactDetails.Forename,
                Surname = contactDetails.Surname,
                RelationToChild = contactDetails.RelationToChild,
                Address = contactDetails.Address,
                Postcode = contactDetails.Postcode,
                TelephoneNumber1 = contactDetails.TelephoneNumber1,
                TelephoneNumber2 = contactDetails.TelephoneNumber2,
                TelephoneNumber3 = contactDetails.TelephoneNumber3,
                Email = contactDetails.Email,
                IsToBeKeptInformed = contactDetails.IsToBeKeptInformed
            };


            if (contactDetails.IsSingleParent == true)
                viewModel.SingleParentStatus = SingleParentStatus.Yes;
            else if (contactDetails.IsSingleParent == false)
                viewModel.SingleParentStatus = SingleParentStatus.No;
            else
                viewModel.SingleParentStatus = SingleParentStatus.NotSpecified;


            if (contactDetails.CorrespondencePreference == null)
                viewModel.CorrespondencePreference = CorrespondencePreference.NoCorrespondence;
            else
                viewModel.CorrespondencePreference = Enum.Parse<CorrespondencePreference>(contactDetails.CorrespondencePreference);


            return View(viewModel);
        }
        [HttpPost]
        public ViewResult ContactDetails(ContactDetailsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var contactDetails = GetContactDetails();

            contactDetails.Title = viewModel.Title;
            contactDetails.Forename = viewModel.Forename;
            contactDetails.Surname = viewModel.Surname;
            contactDetails.RelationToChild = viewModel.RelationToChild;
            contactDetails.Address = viewModel.Address;
            contactDetails.Postcode = viewModel.Postcode;
            contactDetails.TelephoneNumber1 = viewModel.TelephoneNumber1;
            contactDetails.TelephoneNumber2 = viewModel.TelephoneNumber2;
            contactDetails.TelephoneNumber3 = viewModel.TelephoneNumber3;
            contactDetails.Email = viewModel.Email;
            contactDetails.CorrespondencePreference = viewModel.CorrespondencePreference.ToString();
            contactDetails.IsToBeKeptInformed = contactDetails.IsToBeKeptInformed;

            if (viewModel.SingleParentStatus != SingleParentStatus.NotSpecified)
            {
                contactDetails.IsSingleParent = viewModel.SingleParentStatus == SingleParentStatus.Yes;
            }

            _context.SaveChanges();

            return View(viewModel);
        }

        private ContactDetails GetContactDetails()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var contactDetails =
                _context.ContailDetails
                    .FirstOrDefault(c =>
                        c.AspNetUserId == currentUserId
                    );

            if (contactDetails == null)
            {
                contactDetails = new ContactDetails
                {
                    AspNetUserId = currentUserId
                };
                _context.ContailDetails.Add(contactDetails);
                _context.SaveChanges();
            }

            return contactDetails;
        }
    }
}