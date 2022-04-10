using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EricBlogProject.Enums
{
    public enum ModerationType
    {
        [Description("Political Progaganda")]
        Political,
        [Description("Offensive Language")]
        Language,
        [Description("Drug References")]
        Drugs,
        [Description("Threatening Speech")]
        Threatening,
        [Description("Sexual Content")]
        Sexual,
        [Description("Hate Speech")]
        HateSpeech,
        [Description("Targeted Shaming")]
        Shaming
    }
}
