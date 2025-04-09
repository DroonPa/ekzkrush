using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aeroport;

public class Airplane : Component
{
    private string name;
    private Label label;

    public Airplane(string name, Label label)
    {
        this.name = name;
        this.label = label;
    }

    public void RequestLanding()
    {
        label.Text = $"{name}: Запит на посадку...";
        mediator.Notify(this, "RequestLanding");
    }

    public void Land()
    {
        label.Text = $"{name}: Сідає!";
    }

    public void Wait()
    {
        label.Text = $"{name}: Очікує дозволу...";
    }

    public void CompleteLanding()
    {
        label.Text = $"{name}: Сів.";
        mediator.Notify(this, "LandingCompleted");
    }
}
