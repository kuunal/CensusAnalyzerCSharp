using CensusAnalyzerProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public class QuickSort : ISort
    {
        ArrayList list = new ArrayList();

        public List<CensusDAO> sort(List<CensusDAO> data, string field)
        {
            string[] headers = data[0].ToString().Split(",");
            int headerIndex = Array.IndexOf(headers, field);
            data.RemoveAt(0);
            Partition(headerIndex, data, 0 , data.Count-1);
            return data;
        }

        private void Partition(int headerIndex, List<CensusDAO> data, int left, int right)
        {
            if (left < right) { 
                int pi = Quick(headerIndex, data, left, right);
                Partition(headerIndex, data, left, pi - 1);
                Partition(headerIndex, data, pi + 1, right);
            }
        }

        private int Quick(int headerIndex, List<CensusDAO> data, int left, int right)
        {
            string pi = data[right].ToString().Split(",")[headerIndex];
            int piINdex = left;
            for(int index = left; index < right; index++)
            {
                string[] row = data[index].ToString().Split(",");
                if (pi.CompareTo(row[headerIndex])==1)
                {
                    swap(data, piINdex, index);
                    piINdex++;
                }
            }
            swap(data, piINdex, right);
            return piINdex;
        }

        public void swap(List<CensusDAO> data, int element1, int element2)
        {
            var temp = data[element1];
            data[element1] = data[element2];
            data[element2] = temp;
        }
    }
}
