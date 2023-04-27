using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudienceResponse.CMN
{
    public class CMNParticipants
    {
        public int SysID { get; set; }
        public string SeatRowNo { get; set; }
        public int RankID { get; set; }
        public string Initials { get; set; }
        public string Name { get; set; }
        public string Titles { get; set; }
        public string CountryID { get; set; }
        public int Status { get; set; }
        public string UserID { get; set; }
        public byte[] ParticipantImage { get; set; }
        public byte[] IDImage { get; set; }

    }
}
