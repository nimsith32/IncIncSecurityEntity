// PieceWorkWorker.cs
// Author: Nimsith Fernandopulle
// Created: December 15, 2021
// Modified: December 15, 2021
//This is a model representing the data associated with a PieceWorkWorker

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IncIncSecurityEntity.Models
{
    public class PieceWorkWorkerModel
    {
        protected const int seniorEmployeeBasePay = 270;
        internal const int MinMessages = 0;
        internal const int MaxMessages = 15000;
        decimal employeePay;

        /// <summary>
        /// An arbitary integer Id for use with Entity Framework
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Worker's First Name.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The worker must have a first name")]
        [Display(Name = "First Name:")]

        public string FirstName { get; set; }

        /// <summary>
        /// The Worker's Last Name.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The worker must have a last name")]
        [Display(Name = "Last Name:")]

        public string LastName { get; set; }

        /// <summary>
        /// The Worker's Number of Messages according to worker type.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter the number of messages sent")]
        [Display(Name = "Messages Sent:")]
        //[Range(typeof(double), "1", "15000", ErrorMessage = "The Number of Messages sent must be between 1 and 15000")]

        public decimal Messages { get; set; }

        /// <summary>
        /// True if the worker is a Senior worker, False if not.
        /// </summary>
        [Display(Name = "Senior Worker")]
        public bool IsSenior { get; set; }



        /// <summary>
        /// This calculates a worker's pay  based on their pay rate 
        /// </summary>
        /// <returns></returns>
        public decimal GetPay()
        {

            if (IsSenior)
            {

                //Senior Worker Constants
                const decimal FirstPay = 0.018M;
                const decimal SecondPay = 0.021M;
                const decimal ThirdPay = 0.024M;
                const decimal FourthPay = 0.037M;
                const decimal FifthPay = 0.03M;

                const decimal ThresholdCapLowest = 1250;
                const decimal ThresholdCapLow = 2500;
                const decimal ThresholdCapMedium = 3750;
                const decimal ThresholdCapHighest = 5000;

                if (Messages > MinMessages && Messages < ThresholdCapLowest)
                {
                    employeePay = seniorEmployeeBasePay + Messages * FirstPay;
                }
                else if (Messages >= ThresholdCapLowest && Messages < ThresholdCapLow)
                {
                    employeePay = seniorEmployeeBasePay + Messages * SecondPay;
                }
                else if (Messages >= ThresholdCapLow && Messages < ThresholdCapMedium)
                {
                    employeePay = seniorEmployeeBasePay + Messages * ThirdPay;
                }
                else if (Messages >= ThresholdCapMedium && Messages < ThresholdCapHighest)
                {
                    employeePay = seniorEmployeeBasePay + Messages * FourthPay;
                }
                else if (Messages >= ThresholdCapHighest)
                {
                    employeePay = seniorEmployeeBasePay + Messages * FifthPay;
                }

            }

            else
            {
                //Piece Worker Constants
                const decimal PieceFirstPay = 0.02M;
                const decimal PieceSecondPay = 0.024M;
                const decimal PieceThirdPay = 0.028M;
                const decimal PieceFourthPay = 0.034M;
                const decimal PieceFifthPay = 0.04M;

                const decimal PieceThresholdCapLowest = 1250;
                const decimal PieceThresholdCapLow = 2500;
                const decimal PieceThresholdCapMedium = 3750;
                const decimal PieceThresholdCapHighest = 5000;

                if (Messages > MinMessages && Messages < PieceThresholdCapLowest)
                {
                    employeePay = Messages * PieceFirstPay;
                }
                else if (Messages >= PieceThresholdCapLowest && Messages < PieceThresholdCapLow)
                {
                    employeePay = Messages * PieceSecondPay;
                }
                else if (Messages >= PieceThresholdCapLow && Messages < PieceThresholdCapMedium)
                {
                    employeePay = Messages * PieceThirdPay;
                }
                else if (Messages >= PieceThresholdCapMedium && Messages < PieceThresholdCapHighest)
                {
                    employeePay = Messages * PieceFourthPay;
                }
                else if (Messages >= PieceThresholdCapHighest)
                {
                    employeePay = Messages * PieceFifthPay;
                }
            }
            return employeePay;
        }
    }
}