﻿using IMOSApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMOSApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private IMOSContext _dbContext;
        public SupplierController(IMOSContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("GetSuppliers")]
        public IEnumerable<Supplier> Retrieve()
        {
            using (var context = new IMOSContext())
            {
                return _dbContext.Suppliers.ToList();
            }
        }
        [HttpGet("GetSupplier/{id}")]
        public IEnumerable<Supplier> Get(int id)
        {
            using (var context = new IMOSContext())
            {
                IEnumerable<Supplier> tmp = _dbContext.Suppliers.Where(emp => emp.SupplierId == id).ToList();
                return tmp;
            }
        }
        [HttpPost("CreateSupplier")]
        public IActionResult Create([FromBody] Supplier Supplier)
        {
            using (var context = new IMOSContext())
            {
                _dbContext.Suppliers.Add(Supplier);
                _dbContext.SaveChanges();
                return Ok();
            }
        }

        [HttpPut("UpdateSupplier/{Id}")]
        public void Update([FromBody] Supplier Supplier, [FromRoute] int Id)
        {
            using (var context = new IMOSContext())
            {
                var clie = _dbContext.Suppliers.Where(clie => clie.SupplierId == Id).ToList().FirstOrDefault();
                //emp.
                _dbContext.SaveChanges();
            }
        }
        [HttpDelete("DeleteSupplier/{Id}")]
        public void Delete(int id)
        {
            using (var context = new IMOSContext())
            {
                var clie = _dbContext.Suppliers.Where(clie => clie.SupplierId == id).ToList().FirstOrDefault(); ;
                _dbContext.Suppliers.Remove(clie);
                _dbContext.SaveChanges();
            }
        }
    }
}