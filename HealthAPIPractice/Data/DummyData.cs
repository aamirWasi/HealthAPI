using HealthAPIPractice.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthAPIPractice.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<HealthContext>();
                context.Database.EnsureCreated();
                if (context.Ailments != null && context.Ailments.Any())
                    return;


                var ailments = GetAilments().ToArray();
                context.Ailments.AddRange(ailments);
                SaveContextChanges(context);


                var medications = GetMedications().ToArray();
                context.Medications.AddRange(medications);
                SaveContextChanges(context);


                var patients = GetPatients(context).ToArray();
                context.Patients.AddRange(patients);
                SaveContextChanges(context);

            }
        }

        private static void SaveContextChanges(HealthContext context)
        {
            context.SaveChanges();
        }

        private static List<Ailment> GetAilments()
        {
            var ailments = new List<Ailment>
            {
                new Ailment{Name="Head Ache"},
                new Ailment{Name="Tummy pain"},
                new Ailment{Name="Flu"},
                new Ailment{Name="Cold"},
            };
            return ailments;
        }
        private static List<Medication> GetMedications()
        {
            var medications = new List<Medication>
            {
                new Medication{Name="Tylelon",Doses="2"},
                new Medication{Name="Asprin",Doses="3"},
                new Medication{Name="Advil",Doses="4"},
                new Medication{Name="Robaxin",Doses="2"},
                new Medication{Name="Voltarin",Doses="1"},
            };
            return medications;
        }
        private static List<Patient> GetPatients(HealthContext db)
        {
            var patients = new List<Patient>
            {
                new Patient
                {
                    Name="Jim Jones",
                    Ailments=new List<Ailment>(db.Ailments.Take(2)),
                    Medications= new List<Medication>(db.Medications.Take(4))
                },
                new Patient
                {
                    Name="Smith",
                    Ailments=new List<Ailment>(db.Ailments.Take(1)),
                    Medications=new List<Medication>(db.Medications.OrderBy(m=>m.Name).Skip(1).Take(2))
                },
                new Patient
                {
                    Name="john",
                    Ailments=new List<Ailment>(db.Ailments.Take(3)),
                    Medications=new List<Medication>(db.Medications.OrderBy(m=>m.Name).Skip(3).Take(2))
                }
            };
            return patients;
        }
    }
}
