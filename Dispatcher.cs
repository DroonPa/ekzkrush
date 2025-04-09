using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aeroport;

public class Dispatcher : IMediator
{
    private List<Airplane> planes = new List<Airplane>();
    private Queue<Airplane> queue = new Queue<Airplane>();
    private bool isRunwayFree = true;

    public void RegisterPlane(Airplane plane)
    {
        plane.SetMediator(this);
        planes.Add(plane);
    }

    public void Notify(object sender, string ev)
    {
        var plane = sender as Airplane;

        if (ev == "RequestLanding")
        {
            if (isRunwayFree)
            {
                isRunwayFree = false;
                plane.Land();

                Timer t = new Timer { Interval = 2000 };
                t.Tick += (s, e) =>
                {
                    t.Stop();
                    plane.CompleteLanding();
                };
                t.Start();
            }
            else
            {
                queue.Enqueue(plane);
                plane.Wait();
            }
        }
        else if (ev == "LandingCompleted")
        {
            isRunwayFree = true;

            if (queue.Count > 0)
            {
                var next = queue.Dequeue();
                Notify(next, "RequestLanding");
            }
        }
    }
}
