using MemoriaVirtual.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MemoriaVirtual.Services
{
	public class ManagementService : Control
	{
        public List<Page> Quadros { get; set; } = new List<Page>();

        public List<string> Fila = new List<string>();
        
        public Stopwatch ExecutionTime = new Stopwatch();

        public List<string> Log = new List<string>();

        public List<string> ExecutionList = new List<string>();

        public List<string> Memory = new List<string>
        {
            "A1",
            "A2",
            "A3"
        };

        public void Update()
        {
            Reset();

            Quadros = new List<Page>();
            Quadro = Memory.FirstOrDefault();
            State = Quadro == "0" ? false : true;

            foreach (var item in Memory)
            {
                if (item == "0")
                {
                    if (State)
                    {
                        Quadros.Add(CreateFrom(item));
                    }
                    else
                    {
                        Count++;
                    }
                }
                else
                {
                    if (State)
                    {
                        Count++;
                    }
                    else
                    {
                        Quadros.Add(CreateFrom(item));
                    }
                }

                ++SizeAt;
            }

            if (Quadros.Count > 0)
            {
                Quadros.Add(CreateFrom(Memory[Index]));
            }
            else
            {
                Quadros.Add(CreateFrom(Memory[Index], true));
            }
        }

        public virtual void Initialize()
        {
            Update();

            foreach (var item in Memory)
            {
                if(item != "0")
                {
                    Fila.Add(item);
                }
            }
        }

        public bool NewPage(Action addFunc, string page)
        {
            bool update = false;
            NewValue = page;
            ExecutionTime.Start();
            Log.Add("ADICIONANDO -> " + NewValue + "\n");

            if (!Memory.Contains(NewValue))
            {
                var i = Memory.IndexOf("0");

                if (i != -1)
                {
                    Log.Add("Endereço adicionado na posição " + i + " da memória.\n");
                    ExecutionList.RemoveAt(0);
                    Memory[i] = NewValue;
                    Fila.Add(NewValue);
                }
                else
                {
                    addFunc.Invoke();
                    ExecutionList.RemoveAt(0);
                    Log.Add("Endereço " + OldValue + " substituido por " + NewValue + " na posição " + TradingPostion + " da memória.\n");
                    update = true;
                }

            }
            else
            {
                ExecutionList.RemoveAt(0);
                Log.Add("Endereço já se encontra na memória.\n");
            }


            ExecutionTime.Stop();

            Log.Add("Tempo: " + ExecutionTime.ElapsedTicks + "\n\n");

            Update();

            return update;
        }

        public void ViewLog()
        {

            Console.WriteLine(" --------------------- MEMORIA INICIAL -------------------------");

            foreach (var item in new List<string>
        {
            "0",
            "0",
            "0"
        })
            {
                Console.WriteLine("| " + item + " |");
            }

            Console.WriteLine(" --------------------- LISTA INICIAL -------------------------");

            foreach (var item in Quadros)
            {
                Console.Write('|' + item.Objective + '|' + item.Initial.ToString() + '|' + item.Size.ToString() + '|' + "->");
            }

            Console.WriteLine();

            Console.WriteLine("\n --------------------- LOG -------------------------");

            foreach (var item in Log)
            {
                Console.Write(item);
            }


            Console.WriteLine(" --------------------- LISTA FINAL -------------------------");

            foreach (var item in Quadros)
            {
                Console.Write('|' + item.Objective + '|' + item.Initial.ToString() + '|' + item.Size.ToString() + '|' + "->");
            }

            Console.WriteLine("\n --------------------- MEMORIA FINAL -------------------------");

            foreach (var item in Memory)
            {
                Console.WriteLine("| " + item + " |");
            }
        }
    }
}
