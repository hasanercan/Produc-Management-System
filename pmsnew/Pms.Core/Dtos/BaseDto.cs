using System;
namespace Pms.Core.Dtos
{
	public abstract class BaseDto
	{
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

