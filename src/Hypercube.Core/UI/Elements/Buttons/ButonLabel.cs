using Hypercube.Mathematics.Dimensions;

namespace Hypercube.Core.UI.Elements.Buttons;

[PublicAPI]
public class ButonLabel : ButonRect
{
    public Label Label { get; private set; } = null!;

    protected override void OnStartup()
    {
        base.OnStartup();
        
        Label = new Label
        {
            AnchorPoint = Vector2.Half,
            Position = HDim2.ScalarHalf,
            Size = HDim2.ScalarOne,
        };

        AddChild(Label);
    }
}