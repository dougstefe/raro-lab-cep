using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RaroLab.Cep.API.ViewModels
{
    public class AddressRequestViewModel
    {
        /// <summary>
        /// Zip code to be consulted. Use only numbers.
        /// </summary>
        [Required(ErrorMessage = "Field 'ZipCode' is required.")]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "Field 'ZipCode' is invalid. Format = 99999999.")]
        //[StringLength(8, ErrorMessage = "Field 'ZipCode' is invalid. StringLength = 8.")]
        public string ZipCode { get; set; }
    }
}
