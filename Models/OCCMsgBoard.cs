//------------------------------------------------------------------------------
//  DATE		NAME		DESC
//  10/23/2014	Chi D.      Created this instead of using the auto generated one, in order to add custom formating.
//------------------------------------------------------------------------------

namespace OCCSolution.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public partial class OCCMessageBoard
	{
		public int OCCMessageBoardID { get; set; }
		public string Message { get; set; }
		public string Title { get; set; }
		public Nullable<bool> isActive { get; set; }
		public string Comments { get; set; }
		
		[DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,
                            HtmlEncode = false,
                            NullDisplayText = "", 
                            DataFormatString = "{0:MM/dd/yyyy}")]  
		public Nullable<System.DateTime> EffectiveDate { get; set; }
		public Nullable<System.DateTime> CreatedDateDate { get; set; }
		public Nullable<System.DateTime> LastUpdatedDate { get; set; }
		public string LastUpdatedUserName { get; set; }
	}
}
