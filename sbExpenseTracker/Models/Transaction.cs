﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbExpenseTracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        
        [Range(1,int.MaxValue,ErrorMessage ="Please Select a category.")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }  //to specify foreign key//? means validations property value can be nullable 
       
        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Note { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [NotMapped]
        public string CategoryTitleWithIcon
        {
            get
            {
                return Category == null ? "" : Category.Icon + "" + Category.Title;

            }
        }

        [NotMapped]
        public string FormatedAmount
        {
            get
            {
                return ((Category == null|| Category.Type == "Expense" ) ? "- " : "+ " ) + Amount.ToString("C0");

            }

        }
     }
}
