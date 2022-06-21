using System.ComponentModel.DataAnnotations;

namespace Modul2Test2.SqlFacade
{
    public class Zadatak
    {
        public int ID { get; set; }
        public int WorkerID { get; set; }
        [Required(ErrorMessage = "Niste uneli naslov!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Niste uneli tezinu zadatka!")]
        [Range(1, 5, ErrorMessage = "Tezina zadatka mora biti izmedju 1-5!")]
        public int Difficulty { get; set; }
        [Required(ErrorMessage = "Niste uneli vreme!")]
        [Range(1, 99999, ErrorMessage = "Vrednost mora biti veca od 1!")]
        public int EstimatedTime { get; set; }
        [Required(ErrorMessage = "Niste uneli opis zadatka!")]
        [StringLength(1024, MinimumLength = 4, ErrorMessage = "Opis mora biti minimum 4,a najvise 1024")]
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
