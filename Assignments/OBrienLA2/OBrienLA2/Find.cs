/*
 * Name: Luke O'Brien
 * Class: 3020:001
 * Due Date: 10/8/21 ->(moved to) 10/11/21
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBrienLA2
{
    class Find
    {
        private Cerial[] data;

        public Find(Cerial[] data)
        {
            this.data = new Cerial[data.Length];

            for(int x=0; x<this.data.Length; x++)
            {
                this.data[x] = data[x];
            }
        }

        /// <summary>
        /// Search method using linQ quries to refine data
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="nutri"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        public Cerial[] Search(double min, double max, int nutri, bool ascending)
        {
            var result = 
                from searchData in data
                where searchData != null && searchData.GetNutrient(nutri) > 0
                orderby searchData
                select searchData;

            if(min != -1 && max != -1)
            {
                result =
                    from searchData in result
                    where searchData.GetNutrient(nutri) >= min && searchData.GetNutrient(nutri) <= max
                    orderby searchData
                    select searchData;
            }
            else if(min == -1 && max != -1)
            {
                result =
                    from searchData in result
                    where searchData.GetNutrient(nutri) <= max
                    orderby searchData
                    select searchData;
            }
            else if(min != -1 && max == -1)
            {
                result =
                    from searchData in result
                    where searchData.GetNutrient(nutri) >= min
                    orderby searchData
                    select searchData;
            }

            if (ascending)
            {
                result =
                    from searchData in result
                    orderby searchData descending
                    select searchData;
            }

            return result.ToArray<Cerial>();
        }
    }
}
