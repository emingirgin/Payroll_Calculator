using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PayrollCalculator.Models
{
    public class PieceworkWorkerModel
    {
        #region "Variable declarations"

        // Instance variables
        private string employeeName;
        private string employeeLastName;
        private int employeeMessages;
        private double employeePay;

        private bool isValid = true;

        // Shared class variables
        protected static int overallNumberOfEmployees = 0;
        private static decimal averagePayroll = 0M;
        protected static int overallMessages = 0;
        protected static decimal overallPayroll = 0M;

        public const int LIMIT1 = 1;
        public const int LIMIT2 = 1250;
        public const int LIMIT3 = 2500;
        public const int LIMIT4 = 3750;
        public const int LIMIT5 = 5000;

        public const double PAYLEVEL1 = 0.025;
        public const double PAYLEVEL2 = 0.03;
        public const double PAYLEVEL3 = 0.035;
        public const double PAYLEVEL4 = 0.041;
        public const double PAYLEVEL5 = 0.048;

        internal const int ONE = 1;
        internal const int UPPERBOUND = 15000;

        new internal const int SENIORLIMIT1 = 1;
        new internal const int SENIORLIMIT2 = 1250;
        new internal const int SENIORLIMIT3 = 2500;
        new internal const int SENIORLIMIT4 = 3750;
        new internal const int SENIORLIMIT5 = 5000;

        internal const double SENIORBASE = 270.00;
        new internal const double SENIORPAYLEVEL1 = 0.018;
        new internal const double SENIORPAYLEVEL2 = 0.021;
        new internal const double SENIORPAYLEVEL3 = 0.024;
        new internal const double SENIORPAYLEVEL4 = 0.027;
        new internal const double SENIORPAYLEVEL5 = 0.03;

        #endregion

        #region "Properties
        /// <summary>
        /// Arbitrary ID required for storage purposes with Entity Framework
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The worker's first name.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The worker must have a first name")]
        [Display(Name = "First Name:")]
        public string Name { get; set; }
        /// <summary>
        /// The worker's last name.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The worker must have a last name")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        /// <summary>
        /// The worker's hours worked.
        /// (double)PieceworkWorker.ONE, (double)PieceworkWorker.UPPERBOUND,
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter value for messages sent")]
        [Range(1, 15000, ErrorMessage = "To calculate the pay messages, value must be in range")]
        [Display(Name = "Messages:")]
        public string Messages { get; set; }
        /// <summary>
        /// The worker type selection
        /// </summary>
        public bool IsSenior { get; set; }
        /// <summary>
        /// Last worker's pay.
        /// </summary>
        public double Pay()
        {
            Int32.TryParse(this.Messages, out int employeeMessages);
            if (IsSenior == false)
            {

                if (employeeMessages >= LIMIT1 && employeeMessages < LIMIT2)
                {
                    employeePay = PAYLEVEL1 * employeeMessages;
                }
                else if (employeeMessages >= LIMIT2 && employeeMessages < LIMIT3)
                {
                    employeePay = PAYLEVEL2 * employeeMessages;
                }
                else if (employeeMessages >= LIMIT3 && employeeMessages < LIMIT4)
                {
                    employeePay = PAYLEVEL3 * employeeMessages;
                }
                else if (employeeMessages >= LIMIT4 && employeeMessages < LIMIT5)
                {
                    employeePay = PAYLEVEL4 * employeeMessages;
                }
                else if (employeeMessages >= LIMIT5)
                {
                    employeePay = PAYLEVEL5 * employeeMessages;
                }
            }
            else
            {
                if (employeeMessages >= SENIORLIMIT1 && employeeMessages < SENIORLIMIT2)
                {
                    employeePay = SENIORPAYLEVEL1 * employeeMessages + SENIORBASE;
                }
                else if (employeeMessages >= SENIORLIMIT2 && employeeMessages < SENIORLIMIT3)
                {
                    employeePay = (SENIORPAYLEVEL2 * employeeMessages) + SENIORBASE;
                }
                else if (employeeMessages >= SENIORLIMIT3 && employeeMessages < SENIORLIMIT4)
                {
                    employeePay = (SENIORPAYLEVEL3 * employeeMessages) + SENIORBASE;
                }
                else if (employeeMessages >= SENIORLIMIT4 && employeeMessages < SENIORLIMIT5)
                {
                    employeePay = (SENIORPAYLEVEL4 * employeeMessages) + SENIORBASE;
                }
                else if (employeeMessages >= SENIORLIMIT5)
                {
                    employeePay = (SENIORPAYLEVEL5 * employeeMessages) + SENIORBASE;
                }
            }

            return employeePay;
        }
        #endregion
    }
}
