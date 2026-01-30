namespace Day21
{
    class PolicyTracker
    {
        Dictionary<string, PolicyTracker> policyDetails = new Dictionary<string,PolicyTracker>();

        public string PolicyId { get; set; }
        public string HolderName { get; set; }
        public decimal Premium { get; set; }
        public int RiskScore { get; set; }
        public DateTime RenewalDate { get; set; }

        public void AddPolicy(PolicyTracker policy)
        {
            policyDetails[policy.PolicyId]=policy;
        }

        public void PremiumIncrease()
        {
            foreach (var v in policyDetails.Values)
            {
                if (v.RiskScore > 75)
                     v.Premium += v.Premium * 0.05m;
            }
        }

        public bool RemovePolicy()
        {
            DateTime threeYearsAgo = DateTime.Today.AddYears(-3);
            foreach(var v in policyDetails.Values)
            {
                if (v.RenewalDate < threeYearsAgo)
                {
                    policyDetails.Remove(v.PolicyId);
                    return true;
                }
            }  
            return false;
        }

        public PolicyTracker SeachPolicy(string id)
        {
            foreach (var v in policyDetails.Values)
            {
                if(v.PolicyId == id)
                    return policyDetails[v.PolicyId];
            }
            return null;
        }

        public override string ToString()
        {
            return $"{PolicyId} {HolderName} {Premium} {RiskScore} {RenewalDate}";
        }

        public void DisplayAllPolicies()
        {
            foreach (var policy in policyDetails.Values)
            {
                Console.WriteLine(policy);
            }
        }

    }

    internal class Exercise01
    {
        static void Main(string[] args)
        {
            PolicyTracker p = new PolicyTracker();
            {
                p.AddPolicy(new PolicyTracker()
                {
                    PolicyId = "A1",
                    HolderName = "Raj",
                    Premium = 567,
                    RiskScore = 60,
                    RenewalDate = new DateTime(2022, 12, 01, 6, 30, 34)
                });

                p.AddPolicy(new PolicyTracker()
                {
                    PolicyId = "B1",
                    HolderName = "Taj",
                    Premium = 967,
                    RiskScore = 80,
                    RenewalDate = new DateTime(2052, 12, 01, 6, 30, 34)
                });

                p.DisplayAllPolicies();
                Console.WriteLine("-------------------------");
                p.PremiumIncrease();
                
                p.DisplayAllPolicies();
                Console.WriteLine("-------------------------");
                PolicyTracker found = p.SeachPolicy("B1");
                if (found==null)
                {
                    Console.WriteLine("Not Found");
                }
                else
                {
                    Console.WriteLine(found);
                }
                Console.WriteLine("-------------------------");
                bool isDeleted = p.RemovePolicy();
                if (isDeleted)
                {
                    Console.WriteLine("Removed Successfully");
                }
                Console.WriteLine("-------------------------");
                p.DisplayAllPolicies();
            }
        }
    }
}