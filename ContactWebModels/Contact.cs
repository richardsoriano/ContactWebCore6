using System.ComponentModel.DataAnnotations;

namespace ContactWebModels
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(ContactWebManagerConstants.MAX_FIRST_NAME_LENGTH)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(ContactWebManagerConstants.MAX_LAST_NAME_LENGTH)]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required")]
        [StringLength(ContactWebManagerConstants.MAX_EMAIL_LENGTH)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Mobile Phone")]
        [Required(ErrorMessage = "Phone Number is required")]
        [StringLength(ContactWebManagerConstants.MAX_PHONE_LENGTH)]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhonePrimary { get; set; }

        [Display(Name = "Home/Office Phone")]
        [Required(ErrorMessage = "Phone Number is required")]
        [StringLength(ContactWebManagerConstants.MAX_PHONE_LENGTH)]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneSecondary { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Street Adress Line 1")]
        [StringLength(ContactWebManagerConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress1 { get; set; }

        [Display(Name = "Street Adress Line 2")]
        [StringLength(ContactWebManagerConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress2 { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [StringLength(ContactWebManagerConstants.MAX_CITY_LENGTH)]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; }
        public virtual State State { get; set; }

        [Required(ErrorMessage = ("Zip Code is required"))]
        [Display(Name = "Zip Code")]
        [StringLength(ContactWebManagerConstants.MAX_ZIP_CODE_LENGTH, MinimumLength = ContactWebManagerConstants.MIN_ZIP_CODE_LENGTH)]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)", ErrorMessage = "Zip code is invalid.")] // US or Canada

        public string Zip { get; set; }
        [Required(ErrorMessage = "The User ID is required in order to map the contact to a user correctly")]
        public string UserId { get; set; }
        [Display(Name = "Full Name")]
        public string FriendlyName => $"{FirstName} {LastName}";
        [Display(Name = "Full Address")]
        public string FriendlyAddress => State is null ? "" : string.IsNullOrWhiteSpace(StreetAddress1) ? $"{City}, {State.Abbreviation}, {Zip}" :
            string.IsNullOrWhiteSpace(StreetAddress2)
            ? $"{StreetAddress1}, {City}, {State.Abbreviation}, {Zip}"
            : $"{StreetAddress1} - {StreetAddress2}, {State.Abbreviation},{Zip}";

    }
}

