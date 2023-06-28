using System;
using DataLayer;
using MODELS;

namespace RULES
{
    public class GetNextPostNumberRule
    {
        static int GetNextPostNumber()
        {
            if (posts.Count > 0)
            {
                return posts[posts.Count - 1].PostNumber + 1;
            }

            return 1;
        }
    }
}
