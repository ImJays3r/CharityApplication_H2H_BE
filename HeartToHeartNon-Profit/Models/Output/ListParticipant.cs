using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Output
{
    public class ListParticipant
    {
        /// <summary>
        /// list mem
        /// </summary>
        public virtual ICollection<ListUserOutput> listMember { get; set; }

        /// <summary>
        /// list manager
        /// </summary>
        public virtual ICollection<ListUserOutput> listManager { get; set; }

        /// <summary>
        /// admin
        /// </summary>
        public ListUserOutput admin { get; set; }
    }
}
