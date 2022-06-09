using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCCSolution.Models
{
    public class ICD9Repository
    {
        private List<ICD> _icds = new List<ICD>()
            {
                new ICD
                    {
                        ICDID = 1,
                        PrimarySite = "LIP, Oral Cavity and Pharynx",
                        ICD10CM =   "140.0-140.6, 140.8, 140.9,141.0-141.6, 141.8, 141.9, 142.0-142.2, 142.8, 142.9, 143.0, 143.1, 143.8, 143.9, 144.0, 144.1, 144.8, 144.9, 145.0-145.6, 145.8, 145.9, 146.0-146.9, 147.0-147.3, 147.8, 147.9, 148.0-148.3, 148.8, 148.9, 149.0, 149.1, 149.8, 149.9", 
                        ICDO3 = "C000-C006, C008-C009, C019-C024, C028-C029, C030-C031,C039-C041, C048-C052, C058-C062, C068-C069, C079-C081,C088-C089, C090-C091, C098-C104, C108-C109, C110-C113,C118-C119, C129-C132, C138-C139, C140, C142, C148"        
                    },

                new ICD
                    {
                        ICDID = 2,
                        PrimarySite = "Esophagus", 
                        ICD10CM = "150.0-151.6, 150.8, 150.9", 
                        ICDO3 = "C150-C155, C158-C159"
                    },

                new ICD
                    {
                        ICDID = 3,
                        PrimarySite = "Stomach", 
                        ICD10CM = "151.0-151.6, 151.8, 151.9, 209.23", 
                        ICDO3 = "C160-C166, C168-C169"
                    },

                new ICD
                    {
                        ICDID = 4,
                        PrimarySite = "Small Intestine", 
                        ICD10CM = "152.0-152.3, 152.8, 152.9, 209.00-209.03", 
                        ICDO3 = "C170-C173, C178-C179"
                    },

                new ICD
                    {
                        ICDID = 5,
                        PrimarySite = "Colon", 
                        ICD10CM = "153.0-153.9, 209.10-209.16", 
                        ICDO3 = "C180-C189"
                    },

                new ICD
                    {
                        ICDID = 6,
                        PrimarySite = "Rectum", 
                        ICD10CM = "154.0, 154.1, 209.17", 
                        ICDO3 = "C199, C209"
                    },  

                new ICD
                    {
                        ICDID = 7,
                        PrimarySite = "Anus", 
                        ICD10CM = "154.2, 154.3, 154.8", 
                        ICDO3 = "C210-C212, C218"
                    },  

                new ICD
                    {
                        ICDID = 8,
                        PrimarySite = "Liver", 
                        ICD10CM = "155.0, 155.1", 
                        ICDO3 = "C220, C221"
                    },  

                new ICD
                    {
                        ICDID = 9,
                        PrimarySite = "Pancreas", 
                        ICD10CM = "157.0-157.4, 157.8, 157.9", 
                        ICDO3 = "C250-C254, C257-C259"
                    },  

                new ICD
                    {
                        ICDID = 10,
                        PrimarySite = "Other Digestive Organ", 
                        ICD10CM = "156.0-156.2, 159.0, 159.1, 159.8, 159.9, 209.25, 209.26, 209.27", 
                        ICDO3 = "C239-C241, C248-C249, C260, C268, C269, C422"
                    },  

                new ICD
                    {
                        ICDID = 11,
                        PrimarySite = "Larynx", 
                        ICD10CM = "161.0-161.3, 161.8, 161.9", 
                        ICDO3 = "C320-C323, C328-C329"
                    },  

                new ICD
                    {
                        ICDID = 12,
                        PrimarySite = "Lung", 
                        ICD10CM = "162.0, 162.2-162.5, 162.8, 162.9, 209.21", 
                        ICDO3 = "C340-C343, C348-C349"
                    },  

                new ICD
                    {
                        ICDID = 13,
                        PrimarySite = "Other Respiratory and Intrathoracic Organs", 
                        ICD10CM = "160.0-160.5, 160.8, 160.9, 163.0, 163.1, 163.8, 163.9, 164.0-164.3, 164.8, 164.9, 165.0, 165.8, 165.9, 209.22", 
                        ICDO3 = "C300, C301, C310-C313, C318-C319, C339, C379, C380, C381-C383, C384, C388, C390, C398-C399"
                    },

                new ICD
                    {
                        ICDID = 14,
                        PrimarySite = "Bones and Joints", 
                        ICD10CM = "170.0-170.9", 
                        ICDO3 = "C400-C403, C408-C414, C418-C419"
                    }, 

                new ICD
                    {
                        ICDID = 15,
                        PrimarySite = "Soft Tissue", 
                        ICD10CM = "158.0, 158.8, 158.9,171.0, 171.2-171.9", 
                        ICDO3 = "C470-C476, C478-C479, C480-C482, C488, C490-C496, C498-C499"
                    }, 

                new ICD
                    {
                        ICDID = 16,
                        PrimarySite = "Melanoma", 
                        ICD10CM = "172.0-172.9", 
                        ICDO3 = "C440-C449 (includes histology codes 8720-8790 only)"
                    }, 

                new ICD
                    {
                        ICDID = 17,
                        PrimarySite = "Kaposi’s sarcoma", 
                        ICD10CM = "176.0-176.5, 176.8, 176.9", 
                        ICDO3 = "9140"
                    }, 

                new ICD
                    {
                        ICDID = 18,
                        PrimarySite = "Mycosis Fungoides", 
                        ICD10CM = "202.1", 
                        ICDO3 = "9700"
                    }, 

                new ICD
                    {
                        ICDID = 19,
                        PrimarySite = "Other Skin", 
                        ICD10CM = "173.00-173.99, 209.31-209.36", 
                        ICDO3 = "C440-C449 (excludes histology code 8720-8790)"
                    }, 

                new ICD
                    {
                        ICDID = 20,
                        PrimarySite = "Breast - Female ", 
                        ICD10CM = "174.0-174.6, 174.8, 174.9", 
                        ICDO3 = "C500-C506, C508-C509"
                    }, 

                new ICD
                    {
                        ICDID = 21,
                        PrimarySite = "Breast - Male ", 
                        ICD10CM = "175.0, 175.9", 
                        ICDO3 = "C500-C506, C508-C509"
                    }, 
                new ICD
                    {
                        ICDID = 22,
                        PrimarySite = "Cervix Uteri", 
                        ICD10CM = "180.0, 180.1, 180.8, 180.9", 
                        ICDO3 = "C530-C531, C538-C539"
                    }, 

                new ICD
                    {
                        ICDID = 23,
                        PrimarySite = "Corpus Uteri", 
                        ICD10CM = "179, 182.0, 182.1, 182.8", 
                        ICDO3 = "C540-C543, C548-C549, C559"
                    }, 

                new ICD
                    {
                        ICDID = 24,
                        PrimarySite = "Ovary", 
                        ICD10CM = "183.0", 
                        ICDO3 = "C569"
                    }, 

                new ICD
                    {
                        ICDID = 25,
                        PrimarySite = "Other Female Genital", 
                        ICD10CM = "181, 183.2-183.5, 183.8, 183.9, 184.0-184.4, 184.8, 184.9", 
                        ICDO3 = "C510-C512, C518-C519, C529, C570-C574, C577-C579, C589"
                    }, 

                new ICD
                    {
                        ICDID = 26,
                        PrimarySite = "Prostate", 
                        ICD10CM = "185", 
                        ICDO3 = "C619"
                    }, 
                    
                new ICD
                    {
                        ICDID = 27,
                        PrimarySite = "Other Male Genital", 
                        ICD10CM = "186.0, 186.9, 187.1-187.9", 
                        ICDO3 = "C600-C602, C608-C609, C620-C621, C629, C630, C631, C632, C637-C639"
                    }, 
                                        
                new ICD
                    {
                        ICDID = 28,
                        PrimarySite = "Bladder", 
                        ICD10CM = "188.0-188.9", 
                        ICDO3 = "C670-C679"
                    }, 

                new ICD
                    {
                        ICDID = 29,
                        PrimarySite = "Kidney", 
                        ICD10CM = "189.0, 189.1, 209.24", 
                        ICDO3 = "C649"
                    }, 

                new ICD
                    {
                        ICDID = 30,
                        PrimarySite = "Other Urinary", 
                        ICD10CM = "189.2-189.4, 189.8, 189.9", 
                        ICDO3 = "C659, C669, C680-C681, C688-C689"
                    }, 

                    
                new ICD
                    {
                        ICDID = 31,
                        PrimarySite = "Eye and Orbit", 
                        ICD10CM = "190.0-190.9", 
                        ICDO3 = "C690-C691, C692, C693, C694, C695-C698, C699"
                    }, 

                new ICD
                    {
                        ICDID = 32,
                        PrimarySite = "Brain and Nervous System", 
                        ICD10CM = "191.0-191.9, 192.0-192.3, 192.8, 192.9", 
                        ICDO3 = "C700-C701, C709, C710-C714, C715, C716, C717-C719, C720-C725, C728-C729"
                    }, 

                new ICD
                    {
                        ICDID = 33,
                        PrimarySite = "Thyroid", 
                        ICD10CM = "193", 
                        ICDO3 = "C739"
                    }, 

                new ICD
                    {
                        ICDID = 34,
                        PrimarySite = "Other Endocrine System", 
                        ICD10CM = "194.0, 194.1, 194.3-194.6, 194.8, 194.9", 
                        ICDO3 = "C740-C741, C749, C750, C751-C752, C753, C754-C755, C758-C759"
                    }, 

                new ICD
                    {
                        ICDID = 35,
                        PrimarySite = "Non-Hodgkin Lymphoma", 
                        ICD10CM = "200.0 – 200.8, 202.0, 202.2, 202.7 – 202.9", 
                        ICDO3 = "9590, 9591, 9596, 9597, 9670, 9671, 9673, 9675, 9678-9680, 9684, 9687-9691, 9695, 9698, 9699, 9701, 9702, 9705, 9708, 9709, 9712, 9714, 9716-9719, 9724-9729, 9735, 9737, 9738"
                    }, 

                new ICD
                    {
                        ICDID = 36,
                        PrimarySite = "Hodgkin Lymphoma", 
                        ICD10CM = "201.0-201.2, 201.4-201.7, 201.9", 
                        ICDO3 = "9650-9655, 9659, 9663-9665, 9667"
                    }, 

                new ICD
                    {
                        ICDID = 37,
                        PrimarySite = "Multiple Myeloma", 
                        ICD10CM = "203.0, 203.1", 
                        ICDO3 = "9732-9733"
                    }, 

                new ICD
                    {
                        ICDID = 38,
                        PrimarySite = "Lymphoid Leukemia", 
                        ICD10CM = "204.0-204.2, 204.8, 204.9", 
                        ICDO3 = "9811-9818, 9820, 9823, 9826, 9827, 9831-9837"
                    }, 

                new ICD
                    {
                        ICDID = 39,
                        PrimarySite = "Myeloid and Monocytic Leukemia", 
                        ICD10CM = "205.0-205.3, 205.8, 205.9, 206.0-206.2, 206.8, 206.9, 207.0", 
                        ICDO3 = "9840, 9860-9861, 9863, 9865-9867, 9869, 9870-9876, 9891, 9895-9898, 9910, 9911, 9920, 9930, 9945, 9946, 9963 "
                    }, 

                new ICD
                    {
                        ICDID = 40,
                        PrimarySite = "Leukemia, other", 
                        ICD10CM = "202.4, 207.1, 207.8, 208.0-208.2, 208.8, 208.9", 
                        ICDO3 = "9742, 9800, 9801, 9805-9809, 9931, 9940, 9948, 9964"
                    }, 
                new ICD
                    {
                        ICDID = 41,
                        PrimarySite = "Other Hematopoietic", 
                        ICD10CM = "202.3, 202.5, 202.6, 203.8, 238.4, 238.6, 238.71, 238.72, 238.73, 238.74, 238.75, 238.76, 238.79, 273.3", 
                        ICDO3 = "9731, 9734, 9740, 9741, 9751, 9754-9759, 9760-9762, 9764, 9950, 9960-9962, 9965-9967, 9971, 9975, 9980, 9982, 9983, 9985-9987, 9989,9991, 9992  "
                    }, 
                new ICD
                    {
                        ICDID = 42,
                        PrimarySite = "Unknown Sites", 
                        ICD10CM = "199.0, 199.1, 209.20, 209.29, 209.31", 
                        ICDO3 = "C809"
                    }, 
                new ICD
                    {
                        ICDID = 43,
                        PrimarySite = "Ill-Defined Sites", 
                        ICD10CM = "195.0-195.5, 195.8", 
                        ICDO3 = "C760-C768"
                    }, 
            };

        public IEnumerable<ICD> 
            
        GetICDs()
        {
            return _icds;  
        }

    }
}