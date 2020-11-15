using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;
using AutoMapper;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public bool IsSubcribedToNewsLetter { get; set; }
        
        [Required(ErrorMessage = "Please Select a Membership type")]
        public byte MemberShipTypeId { get; set; }

        public MembershipTypeDto MembershipType{ get; set; }

        [Required]
        [ValidateAge(18)]
        public DateTime? BirthDate { get; set; }

        public class ValidateAge : ValidationAttribute
        {
            public int AgeLimit;
            public MembershipType MembershipType;

            public ValidateAge(int validateAgeLimit)
            {
                AgeLimit = validateAgeLimit;
            }
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {

        
                var customer = (CustomerDto)validationContext.ObjectInstance;
                if (customer.MemberShipTypeId == MembershipType.Unknown || customer.MemberShipTypeId == MembershipType.PayAsYouGo)
                    return ValidationResult.Success;

                if (customer.BirthDate == null)
                {
                    return new ValidationResult("Birthdate is required");
                }

                var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
                return (age >= AgeLimit) ? ValidationResult.Success : new ValidationResult($"Your Age must be at least {AgeLimit} years old to be member");

            }
        }


    }
}