﻿using System.Windows;
using System.Windows.Controls;
using Lift.UI.Data;

namespace Lift.UI.Tools;

public class ComboBoxItemCapsuleStyleSelector : StyleSelector
{
    public override Style SelectStyle(object item, DependencyObject container)
    {
        if (container is ComboBoxItem comboBoxItem && VisualHelper.GetParent<ComboBox>(comboBoxItem) is { } comboBox)
        {
            var count = comboBox.Items.Count;
            if (count == 1)
            {
                return ResourceHelper.GetResourceInternal<Style>(ResourceToken.ComboBoxItemCapsuleSingle);
            }

            var index = comboBox.ItemContainerGenerator.IndexFromContainer(comboBoxItem);
            return index == 0
                ? ResourceHelper.GetResourceInternal<Style>(ResourceToken.ComboBoxItemCapsuleHorizontalFirst)
                : ResourceHelper.GetResourceInternal<Style>(index == count - 1
                    ? ResourceToken.ComboBoxItemCapsuleHorizontalLast
                    : ResourceToken.ComboBoxItemCapsuleDefault);
        }

        return null;
    }
}
