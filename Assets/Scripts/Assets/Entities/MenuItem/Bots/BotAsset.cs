using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BotAsset : MenuItemAsset
{
    public override Type objectType { get { return typeof(BotEntity); } }
}

