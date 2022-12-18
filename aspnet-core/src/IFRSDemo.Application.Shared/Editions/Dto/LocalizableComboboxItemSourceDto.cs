using System.Collections.ObjectModel;

namespace IFRSDemo.Editions.Dto
{
	//Mapped in CustomDtoMapper
	public class LocalizableComboboxItemSourceDto
	{
		public Collection<LocalizableComboboxItemDto> Items { get; set; }
	}
}