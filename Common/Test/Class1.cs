using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

namespace Test
{
    [DataContract]
    public class WeiXinMenu
    {
        [DataMember(Name = "button")]
        public List<WeiXinMenuButton> Button
        {
            get;
            set;
        }
    }

    [DataContract]
    public class WeiXinMenuButton : WeiXinMenuButtonBase
    {

        [DataMember(Name = "sub_button")]
        public List<WeiXinMenuSubButton> SubButton
        {
            get;
            set;
        }

    }

    [DataContract]
    public class WeiXinMenuSubButton : WeiXinMenuButtonBase
    {

    }

    [DataContract]
    public abstract class WeiXinMenuButtonBase
    {
        [DataMember(Name = "type")]
        public ButtonType Type
        {
            get;
            set;
        }

        [DataMember(Name = "name")]
        public string Name
        {
            get;
            set;
        }

        [DataMember(Name = "key")]
        public string Key
        {
            get;
            set;
        }
    }

    public enum ButtonType
    {
        Click,
        View
    }
}
