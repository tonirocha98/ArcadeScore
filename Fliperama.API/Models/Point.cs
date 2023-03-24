using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fliperama.API.Repositories
{
    public class Point
    {
        public Point()
        {
            Id = Guid.NewGuid().ToString();
            //OrderStatus = EOrderStatus.NotIntegrated;
            //OrderItems = new HashSet<OrderItem>();
            //PaymentMethods = new HashSet<PaymentMethod>();
        }


        public string Id { get; private set; }
        public string Jogador { get; set; }
        
        public int Valor { get; set; }
        
        public string Data { get; set; }
        public DateTime DataPartida { get; set; }

        //public EOrderStatus OrderStatus { get; private set; }

        //public string OrderCode { get; private set; }

        //public long StoreCode { get; private set; }

        //public long PdvCode { get; private set; }

        //public long PdvOperatorCode { get; private set; }

        //public long Coupon { get; private set; }

        //public decimal OrderAmount { get; private set; }

        //public decimal BilledAmount { get; private set; }

        //public decimal TotalDiscountAmount { get; private set; }

        //public decimal ChangeAmount { get; private set; }

        //public int OrderItemsQuantity { get; private set; }

        //public string UserDocument { get; private set; }

        //public DateTime OrderDate { get; private set; }

        //public DateTime? CancelledDate { get; private set; }

        //public ICollection<PaymentMethod> PaymentMethods { get; private set; }

        //public ICollection<OrderItem> OrderItems { get; private set; }

        //public void SetOrderStatus(EOrderStatus status) => OrderStatus = status;

        //public bool IsValidToIntegrate()
        //{
        //    return !OrderStatus.Equals(EOrderStatus.Integrated) ||
        //           !OrderStatus.Equals(EOrderStatus.Cancelled) ||
        //           !OrderStatus.Equals(EOrderStatus.EmptyItems);
        //}

        //public void Cancel()
        //{
        //    OrderStatus = EOrderStatus.Cancelled;
        //    CancelledDate = DateTime.UtcNow.FormatToLocalDateTimeZone();
        //}
    }
}

