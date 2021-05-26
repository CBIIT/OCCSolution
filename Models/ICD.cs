/*<!--COMMENTS-------------------------------------------------------------------------------------------------------
 * Date           Developer        Desc
 * 09/21/2015     Chi              Attempted to deploy ICD 10 Updates
 *                                 Files: ICD.cs model, ICDView.cshtml view, GrantFundingController.cs controller,
 *                                 and ICD10Repository.cs Data file.
------------------------------------------------------------------------------------------------------------------->*/

namespace OCCSolution.Models
{
    public class ICD
    {
        public int ICDID { get; set; }
        public string PrimarySite { get; set; }
        public string ICD10CM { get; set; }
        public string ICDO3 { get; set; }
    }

}