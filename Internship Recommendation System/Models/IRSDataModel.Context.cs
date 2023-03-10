//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Internship_Recommendation_System.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class IRSEntities : DbContext
    {
        public IRSEntities()
            : base("name=IRSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AgeRange> AgeRanges { get; set; }
        public virtual DbSet<ApprovedIE> ApprovedIEs { get; set; }
        public virtual DbSet<CGUnit> CGUnits { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<ExpectedPeriod> ExpectedPeriods { get; set; }
        public virtual DbSet<InternshipExperience> InternshipExperiences { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<UniYear> UniYears { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        [DbFunction("IRSEntities", "getRecommendation")]
        public virtual IQueryable<getRecommendation_Result> getRecommendation(Nullable<int> jobID, Nullable<int> uniID, Nullable<int> degreeID, Nullable<int> uniYearID, Nullable<bool> isCompleted, Nullable<int> ageID, string gender, Nullable<int> internshipPeriod, Nullable<int> para1W, Nullable<int> para2W, Nullable<int> para3W, Nullable<int> para4W, Nullable<int> para5W, Nullable<int> para6W, Nullable<int> para7W, Nullable<int> para8W, Nullable<int> para9W, Nullable<int> para10W)
        {
            var jobIDParameter = jobID.HasValue ?
                new ObjectParameter("JobID", jobID) :
                new ObjectParameter("JobID", typeof(int));
    
            var uniIDParameter = uniID.HasValue ?
                new ObjectParameter("UniID", uniID) :
                new ObjectParameter("UniID", typeof(int));
    
            var degreeIDParameter = degreeID.HasValue ?
                new ObjectParameter("DegreeID", degreeID) :
                new ObjectParameter("DegreeID", typeof(int));
    
            var uniYearIDParameter = uniYearID.HasValue ?
                new ObjectParameter("UniYearID", uniYearID) :
                new ObjectParameter("UniYearID", typeof(int));
    
            var isCompletedParameter = isCompleted.HasValue ?
                new ObjectParameter("IsCompleted", isCompleted) :
                new ObjectParameter("IsCompleted", typeof(bool));
    
            var ageIDParameter = ageID.HasValue ?
                new ObjectParameter("AgeID", ageID) :
                new ObjectParameter("AgeID", typeof(int));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var internshipPeriodParameter = internshipPeriod.HasValue ?
                new ObjectParameter("InternshipPeriod", internshipPeriod) :
                new ObjectParameter("InternshipPeriod", typeof(int));
    
            var para1WParameter = para1W.HasValue ?
                new ObjectParameter("Para1W", para1W) :
                new ObjectParameter("Para1W", typeof(int));
    
            var para2WParameter = para2W.HasValue ?
                new ObjectParameter("Para2W", para2W) :
                new ObjectParameter("Para2W", typeof(int));
    
            var para3WParameter = para3W.HasValue ?
                new ObjectParameter("Para3W", para3W) :
                new ObjectParameter("Para3W", typeof(int));
    
            var para4WParameter = para4W.HasValue ?
                new ObjectParameter("Para4W", para4W) :
                new ObjectParameter("Para4W", typeof(int));
    
            var para5WParameter = para5W.HasValue ?
                new ObjectParameter("Para5W", para5W) :
                new ObjectParameter("Para5W", typeof(int));
    
            var para6WParameter = para6W.HasValue ?
                new ObjectParameter("Para6W", para6W) :
                new ObjectParameter("Para6W", typeof(int));
    
            var para7WParameter = para7W.HasValue ?
                new ObjectParameter("Para7W", para7W) :
                new ObjectParameter("Para7W", typeof(int));
    
            var para8WParameter = para8W.HasValue ?
                new ObjectParameter("Para8W", para8W) :
                new ObjectParameter("Para8W", typeof(int));
    
            var para9WParameter = para9W.HasValue ?
                new ObjectParameter("Para9W", para9W) :
                new ObjectParameter("Para9W", typeof(int));
    
            var para10WParameter = para10W.HasValue ?
                new ObjectParameter("Para10W", para10W) :
                new ObjectParameter("Para10W", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<getRecommendation_Result>("[IRSEntities].[getRecommendation](@JobID, @UniID, @DegreeID, @UniYearID, @IsCompleted, @AgeID, @Gender, @InternshipPeriod, @Para1W, @Para2W, @Para3W, @Para4W, @Para5W, @Para6W, @Para7W, @Para8W, @Para9W, @Para10W)", jobIDParameter, uniIDParameter, degreeIDParameter, uniYearIDParameter, isCompletedParameter, ageIDParameter, genderParameter, internshipPeriodParameter, para1WParameter, para2WParameter, para3WParameter, para4WParameter, para5WParameter, para6WParameter, para7WParameter, para8WParameter, para9WParameter, para10WParameter);
        }
    
        public virtual int AddApprovedEXPs(Nullable<int> expID)
        {
            var expIDParameter = expID.HasValue ?
                new ObjectParameter("ExpID", expID) :
                new ObjectParameter("ExpID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddApprovedEXPs", expIDParameter);
        }
    }
}
