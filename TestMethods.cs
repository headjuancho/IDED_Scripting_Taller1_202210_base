using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1
{
    internal class TestMethods
    {
        internal enum EValueType
        {
            Two,
            Three,
            Five,
            Seven,
            Prime
        }

        internal static Stack<int> GetNextGreaterValue(Stack<int> sourceStack)
        {
            int[] newarr = sourceStack.ToArray();
            newarr = FillArrayInversed(newarr);

            Stack<int> resultado = new Stack<int>();

            for (int i = 0; i <= sourceStack.Count - 1; i++)
            {
                if (i == (sourceStack.Count - 1))
                {
                    resultado.Push(-1);
                    break;
                }

                for (int j = i + 1; j < sourceStack.Count; j++)
                {
                    if (newarr[i] < newarr[j])
                    {
                        resultado.Push(newarr[j]);
                        i++;
                    }

                    if (j == sourceStack.Count - 1)
                    {
                        if (newarr[i] < newarr[j])
                        {
                            resultado.Push(newarr[j]);
                        }
                        else
                            resultado.Push(-1);
                    }

                }
            }


            return resultado;
        }

        internal static int[] FillArrayInversed(int[] arr)
        {
            int[] resultado = new int[arr.Length];

            int j = 0;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                resultado[j] = arr[i];
                j++;
            }

            return resultado;
        }

        internal static Dictionary<int, EValueType> FillDictionaryFromSource(int[] sourceArr)
        {
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>();

            foreach (int i in sourceArr)
            {
                if (i % 2 == 0)
                {
                    result.Add(i, EValueType.Two);
                    continue;
                }

                else if (i % 3 == 0)
                {
                    result.Add(i, EValueType.Three);
                    continue;
                }

                else if (i % 5 == 0)
                {
                    result.Add(i, EValueType.Five);
                    continue;
                }

                else if (i % 7 == 0)
                {
                    result.Add(i, EValueType.Seven);
                    continue;
                }

                else
                {
                    result.Add(i, EValueType.Prime);
                    continue;
                }


            }

            return result;

        }

        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type)
        {
            int count = 0;

            foreach (KeyValuePair<int, EValueType> element in sourceDict)
            {
                if (element.Value == type)
                {
                    count++;
                }
            }

            return count;
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)
        {
            KeyValuePair<int, EValueType>[] dictarray = sourceDict.ToArray();

            KeyValuePair<int, EValueType> store;


            for (int i = 0; i < dictarray.Length - 1; i++)
            {

                for (int j = i + 1; j < dictarray.Length; j++)
                {
                    if (dictarray[i].Key < dictarray[j].Key)
                    {
                        store = dictarray[j];
                        dictarray[j] = dictarray[i];
                        dictarray[i] = store;
                    }

                }

            }


            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>();

            for (int i = 0; i < sourceDict.Count; i++)
            {
                result.Add(dictarray[i].Key, dictarray[i].Value);
            }

            return result;
        }

        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {
            /*
            Queue<Ticket>[] result = null;

            return result;
            */

            sourceList = SortTickets(sourceList);

            Queue<Ticket> payment = new Queue<Ticket>();
            Queue<Ticket> subscribe = new Queue<Ticket>();
            Queue<Ticket> cancel = new Queue<Ticket>();

            Queue<Ticket>[] result = { payment, subscribe, cancel };


            foreach (Ticket ticket in sourceList)
            {
                if( ticket.RequestType == Ticket.ERequestType.Payment)
                {
                    result[0].Enqueue(ticket);

                }

                if (ticket.RequestType == Ticket.ERequestType.Subscription)
                {
                    result[1].Enqueue(ticket);

                }

                if (ticket.RequestType == Ticket.ERequestType.Cancellation)
                {
                    result[2].Enqueue(ticket);

                }


            }

            return result;

        }

        internal static List<Ticket> SortTickets(List<Ticket> sourceList)
        {

            Ticket store;

            Ticket[] tickets = sourceList.ToArray();

            List<Ticket> result = new List<Ticket>();

            for (int i = 0; i < tickets.Length; i++)
            {

                for (int j = i + 1; j < tickets.Length; j++)
                {
                    if (tickets[i].Turn > tickets[j].Turn)
                    {
                        store = tickets[i];
                        tickets[i] = tickets[j];
                        tickets[j] = store;
                    }

                }

            }

            foreach(Ticket ticket in tickets)
            {
                result.Add(ticket);
            }

            return result;

        }

        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            bool result;
            if ( ticket.Turn>99)
            {
                result = false;
                return result;
            }
            
            if (ticket.RequestType == targetQueue.Peek().RequestType)
            {
                targetQueue.Enqueue(ticket);
                 result= true;
                return result;

            }
            else
            {
                result = false;
                return result;
            }
            
        }        
    }
}