using HappyTrip.Reservation.System.Domain.Data.Entities;
using HappyTrip.Reservation.System.Domain.Data.Enums;
using HappyTrip.Reservation.System.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HappyTrip.Reservation.System.Repository.DatabaseContext
{
    public class HappyTripContext : DbContext, IHappyTripContext
    {
        public DbSet<Bus> Buses { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Driver> Drivers { get; set; } = default!;
        public DbSet<StopOver> StopOvers { get; set; } = default!;
        public DbSet<Terminal> Terminals { get; set; } = default!;
        public DbSet<Trip> Trips { get; set; } = default!;

        public HappyTripContext(DbContextOptions<HappyTripContext> options) : base(options)
        {
            
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeds sample data on database

            modelBuilder.Entity<Bus>().HasData(
                new Bus(busNumber: "FBC001", 
                        company: "Five Star Bus Co.", 
                        driverID: Guid.NewGuid(),
                        price: 100.00, 
                        capacity: 40, 
                        lid: 40, 
                        busType: BusTypeEnum.Ordinary),
                new Bus(busNumber: "FBC002",
                        company: "Five Star Bus Co.",
                        driverID: Guid.NewGuid(),
                        price: 150.00,
                        capacity: 40,
                        lid: 40,
                        busType: BusTypeEnum.Airconditioned),
                new Bus(busNumber: "FBC003",
                        company: "Five Star Bus Co.",
                        driverID: Guid.NewGuid(),
                        price: 250.00,
                        capacity: 30,
                        lid: 30,
                        busType: BusTypeEnum.Premium));

            modelBuilder.Entity<Customer>().HasData(
                new Customer(customerID: Guid.NewGuid(),
                             firstName: "Katniss",
                             lastName: "Everdeen",
                             birthDate: new DateTime(2000, 01, 01)),
                new Customer(customerID: Guid.NewGuid(),
                             firstName: "Primrose",
                             lastName: "Everdeen",
                             birthDate: new DateTime(2000, 01, 01)),
                new Customer(customerID: Guid.NewGuid(),
                             firstName: "Peeta",
                             lastName: "Mellark",
                             birthDate: new DateTime(2000, 02, 01)),
                new Customer(customerID: Guid.NewGuid(),
                             firstName: "Gale",
                             lastName: "Hawthorne",
                             birthDate: new DateTime(2000, 03, 01)),
                new Customer(customerID: Guid.NewGuid(),
                             firstName: "Haymitch",
                             lastName: "Abernathy",
                             birthDate: new DateTime(2000, 03, 01)));

            modelBuilder.Entity<Driver>().HasData(
                new Driver(driverID: Guid.NewGuid(),
                           firstName: "Beatrice",
                           lastName: "Prior",
                           licenseID: "NO1-12-123451",
                           birthDate: new DateTime(2000, 01, 01)),
                new Driver(driverID: Guid.NewGuid(),
                           firstName: "Caleb",
                           lastName: "Prior",
                           licenseID: "NO1-12-123452",
                           birthDate: new DateTime(2001, 01, 01)),
                new Driver(driverID: Guid.NewGuid(),
                           firstName: "Jeanine",
                           lastName: "Matthews",
                           licenseID: "NO1-12-123453",
                           birthDate: new DateTime(2002, 01, 01)));

            modelBuilder.Entity<StopOver>().HasData(
                new StopOver(tripID: new Guid("222fc3f5-dce8-45d6-8f77-d5365898ff81"),
                             sequence: 1,
                             area: "SLEX",
                             period: TimeSpan.FromMinutes(15)),
                new StopOver(tripID: new Guid("4b7ad05b-dded-48fe-9df3-4d1d554ab236"),
                             sequence: 1,
                             area: "SLEX",
                             period: TimeSpan.FromMinutes(15)));

            modelBuilder.Entity<Terminal>().HasData(
                new Terminal(terminalID: new Guid("d84b40df-15a2-4d27-a75a-1c874dfbeebc"),
                             company: "Five Star Bus Co.",
                             area: "Pasay, Metro Manila"),
                new Terminal(terminalID: new Guid("26bf7f0f-b351-43c1-8b1d-ce92cd2b8971"),
                             company: "Pasay, Metro Manila",
                             area: "Five Star Bus Co."));

            modelBuilder.Entity<Trip>().HasData(
                new Trip(tripID: new Guid("222fc3f5-dce8-45d6-8f77-d5365898ff81"),
                         busNumber: "FBC001",
                         origin: "Pasay, Metro Manila",
                         destination: "Lucena, Quezon",
                         departure: new DateTime(2022, 8, 22, 15, 30, 00),
                         arrival: new DateTime(2022, 8, 22, 19, 15, 00)),
                new Trip(tripID: new Guid("4b7ad05b-dded-48fe-9df3-4d1d554ab236"),
                         busNumber: "FBC001",
                         origin: "Lucena, Quezon",
                         destination: "Pasay, Metro Manila",
                         departure: new DateTime(2022, 8, 22, 15, 30, 00),
                         arrival: new DateTime(2022, 8, 22, 19, 15, 00)),
                new Trip(tripID: new Guid("5bc1d5d8-6907-470e-a725-ef0a7e863733"),
                         busNumber: "FBC002",
                         origin: "Pasay, Metro Manila",
                         destination: "Lucena, Quezon",
                         departure: new DateTime(2022, 8, 23, 15, 30, 00),
                         arrival: new DateTime(2022, 8, 23, 19, 15, 00)),
                new Trip(tripID: new Guid("99e50980-a5a9-4f43-a3c6-95a7a31a769d"),
                         busNumber: "FBC002",
                         origin: "Lucena, Quezon",
                         destination: "Pasay, Metro Manila",
                         departure: new DateTime(2022, 8, 23, 15, 30, 00),
                         arrival: new DateTime(2022, 8, 23, 19, 15, 00)),
                new Trip(tripID: new Guid("3cfb040b-7295-4d8e-b673-c251100e28f5"),
                         busNumber: "FBC003",
                         origin: "Pasay, Metro Manila",
                         destination: "Lucena, Quezon",
                         departure: new DateTime(2022, 8, 24, 15, 30, 00),
                         arrival: new DateTime(2022, 8, 24, 19, 15, 00)),
                new Trip(tripID: new Guid("c280b0c3-82a6-408a-8596-b07940cac28a"),
                         busNumber: "FBC003",
                         origin: "Lucena, Quezon",
                         destination: "Pasay, Metro Manila",
                         departure: new DateTime(2022, 8, 24, 15, 30, 00),
                         arrival: new DateTime(2022, 8, 24, 19, 15, 00)));

            base.OnModelCreating(modelBuilder);
        }
    }
}