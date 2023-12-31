﻿using System.Windows;
using System.Windows.Controls;
using Lift.UI.Data;

namespace Lift.UI.Tools;

public class TabItemCapsuleStyleSelector : StyleSelector
{
    public override Style SelectStyle(object item, DependencyObject container)
    {
        if (container is TabItem tabItem && VisualHelper.GetParent<TabControl>(tabItem) is { } tabControl)
        {
            var count = tabControl.Items.Count;
            if (count == 1)
            {
                return ResourceHelper.GetResourceInternal<Style>(ResourceToken.TabItemCapsuleSingle);
            }

            var index = tabControl.ItemContainerGenerator.IndexFromContainer(tabItem);
            return index == 0
                ? ResourceHelper.GetResourceInternal<Style>(
                    tabControl.TabStripPlacement == Dock.Top || tabControl.TabStripPlacement == Dock.Bottom
                        ? ResourceToken.TabItemCapsuleHorizontalFirst
                        : ResourceToken.TabItemCapsuleVerticalFirst)
                : ResourceHelper.GetResourceInternal<Style>(index == count - 1
                    ? tabControl.TabStripPlacement == Dock.Top || tabControl.TabStripPlacement == Dock.Bottom
                        ? ResourceToken.TabItemCapsuleHorizontalLast
                        : ResourceToken.TabItemCapsuleVerticalLast
                    : ResourceToken.TabItemCapsuleDefault);
        }

        return null;
    }
}
