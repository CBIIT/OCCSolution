using System.Collections.Generic;

/*<!--COMMENTS-------------------------------------------------------------------------------------------------------------------------------------------
    Date           Developer        Desc
 *  09/22/2015      Chi Dinh        Created new since the updates in ICDRepository.cs don't reflect on the website.
 *                                  Dependent Files: ICD.cs model, ICDView.cshtml view, and GrantsFunding.cshtl controller
 *  03/29/2016      Chi             Somehow the view doesn't display the ICD10 and ICD3 for non/Hodgkin Lymphoma column correctly
 *                                  Switch the Primary 
 *  03/31/2016      Chi             Modified local variable _icds to _icd10                               
--------------------------------------------------------------------------------------------------------------------------------------------------------->*/
namespace OCCSolution.Models
{
    public class ICD10Repository
    {
        private List<ICD> _icd10 = new List<ICD>()
            {
                new ICD
                    {
                        ICDID = 1,
                        PrimarySite = "Lip, Oral Cavity and Pharynx",
                        ICD10CM =   "C000-C006, C008-C009, C01, C020-C024, C028-C029, C030-C031, C039-C041, C048-C052, C058-C062, C068-C069,C07,C080- C081, C089, C090-C091,C098-C099, C100-C104, C108-C109, C110-C113, C118-C119, C12,C130-C132, C138-C139,C140, C142, C148",
                        ICDO3 = "C000-C006, C008-C009, C019-C024, C028-C029, C030-C031, C039-C041, C048-C052, C058-C062, C068-C069, C079-C081, C088-C089, C090-C091, C098-C104, C108-C109, C110-C113, C118-C119, C129-C132, C138-C139, C140, C142, C148"
                    },

                new ICD
                    {
                        ICDID = 2,
                        PrimarySite = "Esophagus",
                        ICD10CM = "C153-C155, C158-C159",
                        ICDO3 = "C150-C155, C158-C159"
                    },

                new ICD
                    {
                        ICDID = 3,
                        PrimarySite = "Stomach",
                        ICD10CM = "C160-C166, C168-C169, C7A092",
                        ICDO3 = "C160-C166, C168-C169"
                    },

                new ICD
                    {
                        ICDID = 4,
                        PrimarySite = "Small Intestine",
                        ICD10CM = "C170-C173, C178-C179,C7A010-C7A012, C7A019",
                        ICDO3 = "C170-C173, C178-C179"
                    },

                new ICD
                    {
                        ICDID = 5,
                        PrimarySite = "Colon",
                        ICD10CM = "C180-C189, C19, C7A020-C7A025, C7A029",
                        ICDO3 = "C180-C189, C199"
                    },

                new ICD
                    {
                        ICDID = 6,
                        PrimarySite = "Rectum",
                        ICD10CM = "C20, C7A026",
                        ICDO3 = "C209"
                    },

                new ICD
                    {
                        ICDID = 7,
                        PrimarySite = "Anus",
                        ICD10CM = "C210-C212, C218",
                        ICDO3 = "C210-C212, C218"
                    },

                new ICD
                    {
                        ICDID = 8,
                        PrimarySite = "Liver",
                        ICD10CM = "C220, C222-C224, C227-C229",
                        ICDO3 = "C220"
                    },

                new ICD
                    {
                        ICDID = 9,
                        PrimarySite = "Pancreas",
                        ICD10CM = "C250-C254, C257-C259",
                        ICDO3 = "C250-C254, C257-C259"
                    },

                new ICD
                    {
                        ICDID = 10,
                        PrimarySite = "Other Digestive Organ",
                        ICD10CM = "C221, C23, C240-C241, C248-C249, C260-C261,C269, C7A094-C7A096 ",
                        ICDO3 = "C221, C239-C241, C248-C249, C260, C268, C269, C422"
                    },

                new ICD
                    {
                        ICDID = 11,
                        PrimarySite = "Larynx",
                        ICD10CM = "C320-C323, C328-C329",
                        ICDO3 = "C320-C323, C328-C329"
                    },

                new ICD
                    {
                        ICDID = 12,
                        PrimarySite = "Lung",
                        ICD10CM = "C340-C343, C348-C349,C7A090",
                        ICDO3 = "C340-C343, C348-C349"
                    },

                new ICD
                    {
                        ICDID = 13,
                        PrimarySite = "Other Respiratory and Intrathoracic Organs",
                        ICD10CM = "C300, C301, C310-C313, C318-C319, C33, C37,C380-C384, C388, C390,C399, C450-C452, C457,C459, C7A091 ",
                        ICDO3 = "C300, C301, C310-C313,C318-C319, C339, C379, C380-C384, C388, C390, C398-C399"
                    },
                new ICD
                    {
                        ICDID = 14,
                        PrimarySite = "Bones and Joints",
                        ICD10CM = "C400-C403, C408-C414, C419",
                        ICDO3 = "C400-C403, C408-C414, C418-C419"
                    },

                new ICD
                    {
                        ICDID = 15,
                        PrimarySite = "Soft Tissue",
                        ICD10CM = "C470-C476, C478-C479, C480-C482, C488, C490-C496, C498-C499",
                        ICDO3 = "C470-C476, C478-C479, C480-C482, C488, C490-C496, C498-C499"
                    },

                new ICD
                    {
                        ICDID = 16,
                        PrimarySite = "Melanoma, Skin",
                        ICD10CM = "C430-C439",
                        ICDO3 = "C440-C449 (includes histology codes 8720-8790 only)"
                    },

                new ICD
                    {
                        ICDID = 17,
                        PrimarySite = "Kaposi’s sarcoma",
                        ICD10CM = "C460-C465, C467, C469",
                        ICDO3 = "9140"
                    },

                new ICD
                    {
                        ICDID = 18,
                        PrimarySite = "Mycosis Fungoides",
                        ICD10CM = "C840",
                        ICDO3 = "9700"
                    },

                new ICD
                    {
                        ICDID = 19,
                        PrimarySite = "Other Skin",
                        ICD10CM = "C440-C449, C4a0-C4a9",
                        ICDO3 = "C440-C449 (excludes histology codes 8720-8790)"
                    },

                new ICD
                    {
                        ICDID = 20,
                        PrimarySite = "Breast ",
                        ICD10CM = "C501-C509",
                        ICDO3 = "C500-C506, C508-C509"
                    },

                new ICD
                    {
                        ICDID = 21,
                        PrimarySite = "Cervix Uteri",
                        ICD10CM = "C530-C531, C538-C539",
                        ICDO3 = "C530-C531, C538-C539"
                    },

                new ICD
                    {
                        ICDID = 22,
                        PrimarySite = "Corpus Uteri",
                        ICD10CM = "C540-C543, C548-C549,C55",
                        ICDO3 = "C540-C543, C548-C549, C559"
                    },

                new ICD
                    {
                        ICDID = 23,
                        PrimarySite = "Ovary",
                        ICD10CM = "C560, C561, C569",
                        ICDO3 = "C569"
                    },

                new ICD
                    {
                        ICDID = 24,
                        PrimarySite = "Other Female Genital",
                        ICD10CM = "C510-C512, C518-C519, C52, C5700-C574, C577-C579, C58",
                        ICDO3 = "C510-C512, C518-C519, C529, C570-C574, C577-C579, C589"
                    },

                new ICD
                    {
                        ICDID = 25,
                        PrimarySite = "Prostate",
                        ICD10CM = "C61",
                        ICDO3 = "C619"
                    },

                new ICD
                    {
                        ICDID = 26,
                        PrimarySite = "Other Male Genital",
                        ICD10CM = "C600-C602, C608-C609, C620-C621, C629, C630,C631, C632, C637-C639",
                        ICDO3 = "C600-C602, C608-C609, C620-C621, C629, C630, C631, C632, C637-C639"
                    },

                new ICD
                    {
                        ICDID = 27,
                        PrimarySite = "Bladder",
                        ICD10CM = "C670-C679",
                        ICDO3 = "C670-C679"
                    },

                new ICD
                    {
                        ICDID = 28,
                        PrimarySite = "Kidney",
                        ICD10CM = "C640, C641, C649, C7A093",
                        ICDO3 = "C649"
                    },

                new ICD
                    {
                        ICDID = 29,
                        PrimarySite = "Other Urinary",
                        ICD10CM = "C651, C652, C659, C661, C662, C669, C680-C681,C688-C689",
                        ICDO3 = "C659, C669, C680-C681,C688-C689 "
                    },


                new ICD
                    {
                        ICDID = 30,
                        PrimarySite = "Eye and Orbit",
                        ICD10CM = "C690-C696, C698-C699",
                        ICDO3 = "C690-C696, C698-C699"
                    },

                new ICD
                    {
                        ICDID = 31,
                        PrimarySite = "Brain and Nervous System",
                        ICD10CM = "C700-C701, C709, C710-C719, C720-C725, C729",
                        ICDO3 = "C700-C701, C709, C710-C719, C720-C725, C728-C729"
                    },

                new ICD
                    {
                        ICDID = 32,
                        PrimarySite = "Thyroid",
                        ICD10CM = "C73",
                        ICDO3 = "C739"
                    },

                new ICD
                    {
                        ICDID = 33,
                        PrimarySite = "Other Endocrine System",
                        ICD10CM = "C740-C741, C749, C750-C755, C758-C759",
                        ICDO3 = "C740-C741, C749, C750-C755, C758-C759"
                    },

                new ICD
                    {
                        ICDID = 34,
                        PrimarySite = "Non-Hodgkin Lymphoma -CHI",
                        ICD10CM = "C820-C826, C828-C829, C830-C831, C833, C835, C837-C839, C841, C844, C846, C847, C849, C84A, C84Z, C851-C852, C858-C859, C860-C866, C884",
                        ICDO3 = "9590, 9591, 9596, 9597, 9670, 9671, 9673, 9675, 9678-9680, 9684, 9687-9691, 9695, 9698, 9699, 9701, 9702, 9705, 9708, 9709, 9712, 9714, 9716-9719, 9725-9729, 9735, 9737, 9738"
                    },
                new ICD
                    {
                        ICDID = 35,
                        PrimarySite = "Hodgkin Lymphoma -CHI",
                        ICD10CM = "C810-C814, C817, C819",
                        ICDO3 = "9650-9655, 9659, 9663-9665, 9667"
                    },

                new ICD
                    {
                        ICDID = 36,
                        PrimarySite = "Multiple Myeloma",
                        ICD10CM = "C900",
                        ICDO3 = "9732"
                    },

                new ICD
                    {
                        ICDID = 37,
                        PrimarySite = "Lymphoid Leukemia",
                        ICD10CM = "C910-C911, C913, C915-C916, C919, C91A, C91Z",
                        ICDO3 = "9811-9818, 9820, 9823, 9826, 9827, 9831-9837"
                    },

                new ICD
                    {
                        ICDID = 38,
                        PrimarySite = "Myeloid and Monocytic Leukemia",
                        ICD10CM = "C920-C926, C929, C92A, C92Z, C930-C931, C933,C939, C93Z, C944",
                        ICDO3 = "9860, 9861, 9863, 9865-9867, 9869, 9871-9876,9891, 9895-9898, 9911,9920, 9930, 9931, 9945,9946, 9965-9967"
                    },

                new ICD
                    {
                        ICDID = 39,
                        PrimarySite = "Leukemia, other",
                        ICD10CM = "C901, C914, C940, C942-C943, C948,C950-C951, C959",
                        ICDO3 = "9733, 9742, 9800, 9801, 9805-9809, 9840, 9870,9910, 9940, 9948, 9964"
                    },
                new ICD
                    {
                        ICDID = 40,
                        PrimarySite = "Other Hematopoietic",
                        ICD10CM = "C880, C882-C883, C888-C889, C902-C903, C946,C960, C962, C964-C966,C969, C96A, C96Z, D45, D460- D462, D464, D469,D46A-D46C, D46Z, D470-D471, D473, D474, D47Z1,D47Z9 ",
                        ICDO3 = "9724, 9731, 9734, 9740, 9741, 9751, 9754-9759, 9760-9762, 9764, 9950, 9960-9963, 9971, 9975,9980, 9982, 9983, 9985-9987, 9989, 9991, 9992   "
                    },
                new ICD
                    {
                        ICDID = 41,
                        PrimarySite = "Unknown Sites",
                        ICD10CM = "C800, C801, C802, C7A00, C7A098, C7A1, C7A8",
                        ICDO3 = "C809"
                    },
                new ICD
                    {
                        ICDID = 42,
                        PrimarySite = "Ill-Defined Sites",
                        ICD10CM = "C760-C765, C768",
                        ICDO3 = "C760-C768"
                    },
            };

        public IEnumerable<ICD>

        GetICDs()
        {
            return _icd10;
        }

    }
}