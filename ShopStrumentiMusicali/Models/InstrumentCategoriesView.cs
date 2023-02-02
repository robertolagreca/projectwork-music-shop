using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopStrumentiMusicali.Models
{
	public class InstrumentCategoriesView
	{

		// L'oggetto strumento vuoto che il mio form dovrà compilare
		public Instrument? Instrument {	get; set; }

		public int Quantity { get; set; }
		
        public List<Category>? Categories { get; set; }

     

    }
}
