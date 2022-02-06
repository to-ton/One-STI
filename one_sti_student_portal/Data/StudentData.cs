// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Data.StudentData
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Newtonsoft.Json.Linq;
using one_sti_student_portal.DependencyServices;
using one_sti_student_portal.Helpers;
using one_sti_student_portal.Models;
using one_sti_student_portal.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace one_sti_student_portal.Data
{
  public class StudentData
  {
    private SQLiteAsyncConnection _connection;

    public StudentData()
    {
      this._connection = DependencyService.Get<ISQLite>().SQLiteConnection();
      this._connection.CreateTableAsync<StudentSettings>().Wait();
      this._connection.CreateTableAsync<StudentInformation>().Wait();
      this._connection.CreateTableAsync<StudentHistory>().Wait();
      this._connection.CreateTableAsync<StudentSemester>().Wait();
      this._connection.CreateTableAsync<StudentSubjects>().Wait();
      this._connection.CreateTableAsync<StudentChecklist>().Wait();
      this._connection.CreateTableAsync<CurriculumDetails>().Wait();
      this._connection.CreateTableAsync<StudentGWA>().Wait();
      this._connection.CreateTableAsync<StudentGrades>().Wait();
      this._connection.CreateTableAsync<StudentSchedule>().Wait();
      this._connection.CreateTableAsync<StudentChargesPayment>().Wait();
      this._connection.CreateTableAsync<StudentChargesDueDate>().Wait();
      this._connection.CreateTableAsync<StudentNetAssessment>().Wait();
      this._connection.CreateTableAsync<StudentSettings>().Wait();
      this._connection.CreateTableAsync<MiscDetails>().Wait();
      this._connection.CreateTableAsync<OSFDetails>().Wait();
      this._connection.CreateTableAsync<StudentDueDetails>().Wait();
    }

    public bool HasUser()
    {
      using (List<StudentInformation>.Enumerator enumerator = this._connection.QueryAsync<StudentInformation>("SELECT * FROM StudentInformation").Result.GetEnumerator())
      {
        if (enumerator.MoveNext())
        {
          StudentInformation current = enumerator.Current;
          return true;
        }
      }
      return false;
    }

    public bool ClearData()
    {
      try
      {
        this.DeleteStudentInfo();
        this.DeleteStudentHistory();
        this.DeleteSemester();
        this.DeleteSubjects();
        this.DeleteSchedule();
        this.DeleteSettings();
        this.DeletePaymentCharges();
        this.DeleteChargesDueDate();
        this.DeleteGrades();
        this.DeleteCurriculum();
        this.DeleteChecklist();
        this.DeleteOSFDetails();
        this.DeleteTuitionMiscDetails();
        this.DeleteDueDetails();
        new FeedbackData().DeleteFeedbacks();
        new ApplicationData().DeleteConstants();
        AuthenticationHelper.TokenForUser = (string) null;
        return true;
      }
      catch
      {
        return false;
      }
    }

    public async Task DownloadStudentInformation(string email)
    {
      JObject studentInfoComplete = await new StudentService().get_student_info_complete(email);
      string constantValue = new ApplicationData().GetConstantValue("profilephoto");
      int num = await this.SaveStudentInfo(new StudentInformation()
      {
        AcadLevel = (string) studentInfoComplete["acad_level"],
        Address = (string) studentInfoComplete["address"],
        Age = (string) studentInfoComplete["age"],
        BirthDate = (DateTime) studentInfoComplete["bdate"],
        Campus = (string) studentInfoComplete["campus"],
        CampusDesc = (string) studentInfoComplete["campus_desc"],
        Email = email,
        FirstName = (string) studentInfoComplete["firstname"],
        Hash = (string) studentInfoComplete["hash"],
        LastName = (string) studentInfoComplete["lastname"],
        MiddleName = (string) studentInfoComplete["middle_name"],
        Phone = (string) studentInfoComplete["phone"],
        ProfilePhoto = constantValue,
        Program = (string) studentInfoComplete["program"],
        ProgramShort = (string) studentInfoComplete["program_short"],
        PSCSId = (string) studentInfoComplete["pscs_id"],
        SchoolYear = (string) studentInfoComplete["school_year"],
        SchoolTerm = (string) studentInfoComplete["strm"],
        Sex = (string) studentInfoComplete["sex"]
      });
    }

    public async Task DownloadStudentHistory(string pscsId, string strm)
    {
      JObject studentHistory = await new StudentService().get_student_history(pscsId, strm);
      int num = await this.SaveStudentHistory(new StudentHistory()
      {
        acad_career = (string) studentHistory["ACAD_CAREER"],
        acad_prog = (string) studentHistory["ACAD_PROG"],
        pscs_id = (string) studentHistory["EMPLID"],
        strm = strm
      });
    }

    public Task<int> SaveStudentHistory(StudentHistory studentHistory)
    {
      List<StudentHistory> result = this.GetStudentHistory().Result;
      if (result.Count == 0)
        return this._connection.InsertAsync((object) studentHistory);
      if (!(result.FirstOrDefault<StudentHistory>().pscs_id == studentHistory.pscs_id))
        return this._connection.InsertAsync((object) studentHistory);
      studentHistory.id = result.FirstOrDefault<StudentHistory>().id;
      return this._connection.UpdateAsync((object) studentHistory);
    }

    public Task<List<StudentHistory>> GetStudentHistory(string strm = null) => strm == null ? this._connection.QueryAsync<StudentHistory>("SELECT * FROM StudentHistory") : this._connection.QueryAsync<StudentHistory>("SELECT * FROM StudentHistory WHERE strm LIKE '%" + strm + "%' LIMIT 1");

    public Task DeleteStudentHistory(string strm = null) => strm == null ? (Task) this._connection.QueryAsync<StudentHistory>("DELETE FROM StudentHistory") : (Task) this._connection.QueryAsync<StudentHistory>("DELETE FROM StudentHistory WHERE strm LIKE '%" + strm + "%' LIMIT 1");

    public async Task DownloadStudentInformationById(string id)
    {
      JObject studentInfoById = await new StudentService().get_student_info_by_id(id);
      int num = await this.SaveStudentInfo(new StudentInformation()
      {
        AcadCareerCurrent = (string) studentInfoById["acad_career"],
        AcadLevel = (string) studentInfoById["acad_level"],
        Age = (string) studentInfoById["age"],
        BirthDate = (DateTime) studentInfoById["bdate"],
        Campus = (string) studentInfoById["campus"],
        CampusDesc = (string) studentInfoById["campus_desc"],
        Email = (string) studentInfoById["email"],
        FirstName = (string) studentInfoById["firstname"],
        Hash = (string) studentInfoById["hash"],
        LastName = (string) studentInfoById["lastname"],
        MiddleName = (string) studentInfoById["middle_name"],
        Program = (string) studentInfoById["program"],
        ProgramShort = (string) studentInfoById["program_short"],
        PSCSId = (string) studentInfoById["pscs_id"],
        SchoolYear = (string) studentInfoById["school_year"],
        SchoolTerm = (string) studentInfoById["strm"],
        Sex = (string) studentInfoById["sex"]
      });
    }

    public Task<int> SaveStudentInfo(StudentInformation studentInfo)
    {
      List<StudentInformation> result = this.GetStudentInformation().Result;
      if (result.Count == 0)
        return this._connection.InsertAsync((object) studentInfo);
      if (!(result.FirstOrDefault<StudentInformation>().PSCSId == studentInfo.PSCSId))
        return this._connection.InsertAsync((object) studentInfo);
      studentInfo.Id = result.FirstOrDefault<StudentInformation>().Id;
      return this._connection.UpdateAsync((object) studentInfo);
    }

    public Task DeleteStudentInfo() => (Task) this._connection.QueryAsync<StudentInformation>("DELETE FROM StudentInformation");

    public Task<List<StudentInformation>> GetStudentInformation() => this._connection.QueryAsync<StudentInformation>("SELECT * FROM StudentInformation LIMIT 1");

    public async Task DownloadChecklist(string pscsId, string acadProg)
    {
      JArray curriculumChecklist = await new StudentService().get_curriculum_checklist(pscsId, acadProg);
      string rqrmntGroup = "";
      DateTime dateProcessed = DateTime.MinValue;
      foreach (JToken jtoken in curriculumChecklist)
      {
        rqrmntGroup = (string) jtoken[(object) "RqrmntGroup"];
        string str = (string) jtoken[(object) "EarnedUnits"];
        int num1 = str == "80.00" ? 1 : 0;
        dateProcessed = (DateTime) jtoken[(object) "DateProcessed"];
        int num2 = await this.SaveChecklist(new StudentChecklist()
        {
          Amount = (double) jtoken[(object) "Amount"],
          CourseCode = (string) jtoken[(object) "CourseCode"],
          CourseDesc = (string) jtoken[(object) "CourseDesc"],
          CourseList = (string) jtoken[(object) "CourseList"],
          CourseListDescr = (string) jtoken[(object) "CourseListDescr"],
          DateProcessed = (DateTime) jtoken[(object) "DateProcessed"],
          EarnedUnits = string.IsNullOrWhiteSpace(str) ? "0.00" : str,
          Grade = (string) jtoken[(object) "Grade"],
          GradeDate = (DateTime) jtoken[(object) "GradeDate"],
          PreRequisite = (string) jtoken[(object) "PreRequisite"],
          ReqUnits = (string) jtoken[(object) "ReqUnits"],
          RqrmntDescr = (string) jtoken[(object) "RqrmntDescr"],
          RqrmntGroup = (string) jtoken[(object) "RqrmntGroup"],
          RqrmntGroupDescr = (string) jtoken[(object) "RqrmntGroupDescr"],
          Term = string.IsNullOrWhiteSpace((string) jtoken[(object) "Term"]) ? "N/A" : (string) jtoken[(object) "Term"],
          UpdatedOn = DateTime.Now,
          Status = (string) jtoken[(object) "Status"]
        });
      }
      await this.DownloadCurriculumDetails(pscsId, rqrmntGroup, dateProcessed.ToString("yyyy-MM-dd"));
      rqrmntGroup = (string) null;
    }

    public Task<int> SaveChecklist(StudentChecklist studentChecklist) => this._connection.InsertAsync((object) studentChecklist);

    public Task<List<StudentChecklist>> GetChecklist(string courseList)
    {
      if (!(courseList != "*"))
        return this._connection.QueryAsync<StudentChecklist>("SELECT * FROM StudentChecklist");
      return this._connection.QueryAsync<StudentChecklist>("SELECT * FROM StudentChecklist WHERE CourseList=?", (object) courseList);
    }

    public List<StudentChecklist> GetRequirementDescriptions(
      bool isPreRegistration)
    {
      List<StudentChecklist> source = new List<StudentChecklist>();
      List<StudentChecklist> studentChecklistList = new List<StudentChecklist>();
      foreach (StudentChecklist studentChecklist in !isPreRegistration ? this._connection.QueryAsync<StudentChecklist>("SELECT RqrmntDescr, CourseList, CourseListDescr, Status, IsExpand, UpdatedOn FROM StudentChecklist").Result : this._connection.QueryAsync<StudentChecklist>("SELECT RqrmntDescr, CourseList, CourseListDescr, IsExpand, UpdatedOn FROM StudentChecklist WHERE EarnedUnits='0.00' AND Term='N/A'").Result)
      {
        StudentChecklist items = studentChecklist;
        if (!source.Any<StudentChecklist>((Func<StudentChecklist, bool>) (o => o.CourseList == items.CourseList)))
          source.Add(new StudentChecklist()
          {
            RqrmntDescr = items.RqrmntDescr,
            CourseList = items.CourseList,
            EarnedUnits = items.EarnedUnits,
            ReqUnits = items.ReqUnits,
            IsExpand = items.IsExpand,
            UpdatedOn = items.UpdatedOn
          });
      }
      return source;
    }

    public string GetCourseListDescriptions(string courseList)
    {
      string listDescriptions = "";
      SQLiteAsyncConnection connection = this._connection;
      object[] objArray = new object[1]
      {
        (object) courseList
      };
      foreach (StudentChecklist studentChecklist in connection.QueryAsync<StudentChecklist>("SELECT CourseListDescr FROM StudentChecklist WHERE CourseList=? LIMIT 1", objArray).Result)
        listDescriptions = studentChecklist.CourseListDescr;
      return listDescriptions;
    }

    public Task DeleteChecklist() => (Task) this._connection.QueryAsync<StudentChecklist>("DELETE FROM StudentChecklist");

    public async Task DownloadCurriculumDetails(
      string pscsId,
      string requirementGroup,
      string requirementGroupDate)
    {
      foreach (JToken curriculumDetail in await new StudentService().get_curriculum_details(pscsId, requirementGroup, requirementGroupDate))
      {
        int num = await this.SaveCurriculum(new CurriculumDetails()
        {
          RqrmntGroup = (string) curriculumDetail[(object) "RqrmntGroup"],
          RqrmntGroupLongDescr = (string) curriculumDetail[(object) "RqrmntGroupLongDescr"],
          MinUnitsRequired = (string) curriculumDetail[(object) "MinUnitsRequired"],
          UnitsTaken = (string) curriculumDetail[(object) "UnitsTaken"],
          EffectiveDate = (DateTime) curriculumDetail[(object) "EffectiveDate"]
        });
      }
    }

    public Task<int> SaveCurriculum(CurriculumDetails curriculumDetails) => this._connection.InsertAsync((object) curriculumDetails);

    public Task<List<CurriculumDetails>> GetCurriculum(
      string requirementGroup)
    {
      if (!(requirementGroup != "*"))
        return this._connection.QueryAsync<CurriculumDetails>("SELECT * FROM CurriculumDetails");
      return this._connection.QueryAsync<CurriculumDetails>("SELECT * FROM CurriculumDetails WHERE RqrmntGroup=?", (object) requirementGroup);
    }

    public Task DeleteCurriculum() => (Task) this._connection.QueryAsync<CurriculumDetails>("DELETE FROM CurriculumDetails");

    public Task ExpandCollapse(string courseList, int status) => courseList == "*" ? (Task) this._connection.QueryAsync<StudentChecklist>("UPDATE StudentChecklist SET IsExpand=?", (object) status) : (Task) this._connection.QueryAsync<StudentChecklist>("UPDATE StudentChecklist SET IsExpand=? WHERE CourseList=?", (object) status, (object) courseList);

    public Task<List<StudentChecklist>> GetChecklistPerLevel(
      string rqrmntDec)
    {
      return this._connection.QueryAsync<StudentChecklist>("SELECT IsExpand FROM StudentChecklist WHERE RqrmntDescr LIKE '%" + rqrmntDec + "%'");
    }

    public Task ExpandCollapsePerLevel(string rqrmntDesc, int status) => (Task) this._connection.QueryAsync<StudentChecklist>("UPDATE StudentChecklist SET IsExpand=? WHERE RqrmntDescr LIKE '%" + rqrmntDesc + "%'", (object) status);

    public Task ExpandCollapseAll(int status) => (Task) this._connection.QueryAsync<StudentChecklist>("UPDATE StudentChecklist SET IsExpand=?", (object) status);

    public async Task DownloadAllSemesters(string pscsId)
    {
      foreach (JToken jtoken in await new StudentService().get_student_semester(pscsId))
      {
        int num = await this.SaveSemester(new StudentSemester()
        {
          Program = (string) jtoken[(object) "program"],
          PSCSId = (string) jtoken[(object) "pscs_id"],
          Semester = (string) jtoken[(object) "semester"],
          SemesterDesc = (string) jtoken[(object) "semester_description"],
          UpdatedOn = DateTime.Now
        });
      }
    }

    public Task<int> SaveSemester(StudentSemester studentSemester) => this._connection.InsertAsync((object) studentSemester);

    public Task<List<StudentSemester>> GetSemesters() => this._connection.QueryAsync<StudentSemester>("SELECT * FROM StudentSemester ORDER BY Semester DESC");

    public Task<List<StudentSemester>> GetProgramSemester(string strm) => this._connection.QueryAsync<StudentSemester>("SELECT * FROM StudentSemester WHERE Semester LIKE '%" + strm + "%'");

    public Task<List<StudentSemester>> GetLatestSemester() => this._connection.QueryAsync<StudentSemester>("SELECT * FROM StudentSemester ORDER BY Semester DESC LIMIT 1");

    public Task DeleteSemester() => (Task) this._connection.QueryAsync<StudentSemester>("DELETE FROM StudentSemester");

    public async Task DownloadSubjectsPerSemester(string pscsId, string strm)
    {
      try
      {
        foreach (JToken jtoken in await new StudentService().get_subjects_per_semester(pscsId, strm))
        {
          int num = await this.SaveSubjects(new StudentSubjects()
          {
            ClassNumber = (string) jtoken[(object) "class_number"],
            CourseCareer = (string) jtoken[(object) "course_career"],
            FinalGrade = (string) jtoken[(object) "final_grade"],
            Professor = (string) jtoken[(object) "professor"],
            PSCSId = (string) jtoken[(object) "pscs_id"],
            Semester = (string) jtoken[(object) "semester"],
            SemesterDesc = (string) jtoken[(object) "semester_description"],
            SubjectCode = (string) jtoken[(object) "subject_code"],
            SubjectDesc = (string) jtoken[(object) "subject_description"],
            DatePosted = (DateTime) jtoken[(object) "date_posted"],
            UpdatedOn = DateTime.Now
          });
        }
      }
      catch
      {
      }
    }

    public Task DeleteSubjects() => (Task) this._connection.QueryAsync<StudentSubjects>("DELETE FROM StudentSubjects");

    public Task DeleteSubjects(string strm) => (Task) this._connection.QueryAsync<StudentSubjects>("DELETE FROM StudentSubjects WHERE Semester LIKE '%" + strm + "%'");

    public Task<int> SaveSubjects(StudentSubjects studentSubjects) => this._connection.InsertAsync((object) studentSubjects);

    public Task<List<StudentSubjects>> GetSubjectInfo(string strm)
    {
      Task<List<StudentSubjects>> subjectInfo = this._connection.QueryAsync<StudentSubjects>("SELECT * FROM StudentSubjects WHERE Semester LIKE '%" + strm + "%' ORDER BY SubjectDesc");
      foreach (StudentSubjects studentSubjects in subjectInfo.Result)
      {
        string str = studentSubjects.FinalGrade.Trim();
        if (str.Trim() == "")
        {
          studentSubjects.FinalGrade = "-";
        }
        else
        {
          try
          {
            if (studentSubjects.CourseCareer != "SHS")
            {
              if (Convert.ToInt32(studentSubjects.FinalGrade) >= 100)
                studentSubjects.FinalGrade = studentSubjects.FinalGrade.Insert(1, ".");
            }
          }
          catch
          {
            if (studentSubjects.CourseCareer != "SHS")
              studentSubjects.FinalGrade = str;
          }
        }
      }
      return subjectInfo;
    }

    public Task<List<StudentSubjects>> GetClassSubjectDetails(
      string class_number)
    {
      return this._connection.QueryAsync<StudentSubjects>("SELECT * FROM StudentSubjects WHERE ClassNumber=?", (object) class_number);
    }

    public async Task DownloadSemesterGWA(string pscsId, string strm)
    {
      try
      {
        foreach (JToken jtoken in await new StudentService().get_student_semester_gwa(pscsId, strm))
        {
          int num = await this.SaveGWA(new StudentGWA()
          {
            CumGPA = (string) jtoken[(object) "cum_gpa"],
            CurGPA = (string) jtoken[(object) "cur_gpa"],
            PSCSId = (string) jtoken[(object) "pscs_id"],
            Semester = (string) jtoken[(object) nameof (strm)]
          });
        }
      }
      catch
      {
      }
    }

    public Task<List<StudentGWA>> GetGWA(string strm) => this._connection.QueryAsync<StudentGWA>("SELECT * FROM StudentGWA WHERE Semester LIKE '%" + strm + "%'");

    public Task DeleteGWA(string strm) => strm == "all" ? (Task) this._connection.QueryAsync<StudentGWA>("DELETE FROM StudentGWA") : (Task) this._connection.QueryAsync<StudentGWA>("DELETE FROM StudentGWA WHERE Semester LIKE '%" + strm + "%'");

    public Task<int> SaveGWA(StudentGWA studentGWA) => this._connection.InsertAsync((object) studentGWA);

    public async Task DownloadSemesterGrades(string pscsId, string strm)
    {
      try
      {
        foreach (JToken jtoken in await new StudentService().get_all_student_subject_grade(pscsId, strm))
        {
          int num = await this.SaveGrades(new StudentGrades()
          {
            ClassNumber = (string) jtoken[(object) "class_number"],
            CourseCareer = (string) jtoken[(object) "course_career"],
            GradingPeriod = (string) jtoken[(object) "grading_period"],
            PeriodGrade = (string) jtoken[(object) "period_grade"],
            PSCSId = (string) jtoken[(object) "pscs_id"],
            Semester = (string) jtoken[(object) "semester"],
            SequenceNumber = (string) jtoken[(object) "sequence_number"],
            SubmittedOn = (DateTime) jtoken[(object) "submitted_date"],
            SyncedOn = DateTime.Now
          });
        }
      }
      catch
      {
      }
    }

    public Task DeleteGrades() => (Task) this._connection.QueryAsync<StudentGrades>("DELETE FROM StudentGrades");

    public Task DeleteGrades(string strm) => (Task) this._connection.QueryAsync<StudentGrades>("DELETE FROM StudentGrades WHERE Semester LIKE '%" + strm + "%'");

    public Task<int> SaveGrades(StudentGrades studentGrades) => this._connection.InsertAsync((object) studentGrades);

    public Task<List<StudentGrades>> GetSubjectGradeDetail(
      string strm,
      string class_number)
    {
      Task<List<StudentGrades>> subjectGradeDetail = this._connection.QueryAsync<StudentGrades>("SELECT * FROM StudentGrades WHERE Semester LIKE '%" + strm + "%' AND ClassNumber='" + class_number + "' and GradingPeriod <>'' ORDER BY SequenceNumber");
      foreach (StudentGrades studentGrades in subjectGradeDetail.Result)
      {
        if (studentGrades.PeriodGrade.Trim() == "" || Convert.ToDecimal(studentGrades.PeriodGrade) == 0M)
          studentGrades.PeriodGrade = "-";
      }
      return subjectGradeDetail;
    }

    public async Task DownloadSchedulePerSem(string pscsId, string strm)
    {
      foreach (JToken jtoken in await new StudentService().get_schedule_per_sem(pscsId, strm))
      {
        int num = await this.SaveSchedule(new StudentSchedule()
        {
          ClassNumber = (string) jtoken[(object) "class_number"],
          MeetingTimeEnd = (string) jtoken[(object) "MEETING_TIME_END"],
          MeetingTimeStart = (string) jtoken[(object) "MEETING_TIME_START"],
          AddDate = (DateTime) jtoken[(object) "ENRL_ADD_DT"],
          PSCSId = (string) jtoken[(object) "pscs_id"],
          RoomCode = (string) jtoken[(object) "room_code"],
          Semester = (string) jtoken[(object) "semester"],
          SemesterDesc = (string) jtoken[(object) "semester_description"],
          SubjectDesc = (string) jtoken[(object) "subject_description"],
          Monday = (bool) jtoken[(object) "monday"],
          Tuesday = (bool) jtoken[(object) "tuesday"],
          Wednesday = (bool) jtoken[(object) "wednesday"],
          Thursday = (bool) jtoken[(object) "thursday"],
          Friday = (bool) jtoken[(object) "friday"],
          Saturday = (bool) jtoken[(object) "saturday"],
          Sunday = (bool) jtoken[(object) "sunday"],
          UpdatedOn = DateTime.Now
        });
      }
    }

    public Task DeleteSchedule() => (Task) this._connection.QueryAsync<StudentSchedule>("DELETE FROM StudentSchedule");

    public Task DeleteSchedule(string strm) => (Task) this._connection.QueryAsync<StudentSchedule>("DELETE FROM StudentSchedule WHERE Semester LIKE '%" + strm + "%'");

    public Task<int> SaveSchedule(StudentSchedule studentSchedule) => this._connection.InsertAsync((object) studentSchedule);

    public List<StudentSchedule> GetSchedule(string strm, string day)
    {
      List<StudentSchedule> schedule = new List<StudentSchedule>();
      List<StudentSchedule> studentScheduleList = new List<StudentSchedule>();
      List<StudentSchedule> result;
      if (day == "0")
      {
        result = this._connection.QueryAsync<StudentSchedule>("SELECT * FROM StudentSchedule WHERE semester='" + strm + "'").Result;
      }
      else
      {
        string str = day.ToLower() + "='1'";
        result = this._connection.QueryAsync<StudentSchedule>("SELECT * FROM StudentSchedule WHERE semester='" + strm + "' AND " + str + " ORDER BY MeetingTimeStart").Result;
      }
      foreach (StudentSchedule studentSchedule in result)
      {
        if (!schedule.Contains(studentSchedule))
          schedule.Add(studentSchedule);
      }
      return schedule;
    }

    public async Task DownloadNetAssessment(string pscsId)
    {
      foreach (JToken jtoken in await new StudentService().get_student_net_assessment(pscsId))
      {
        int num = await this.SaveNetAssessment(new StudentNetAssessment()
        {
          BusinessUnit = (string) jtoken[(object) "BusinessUnit"],
          CommonId = (string) jtoken[(object) "CommonId"],
          DueAmount = (double) jtoken[(object) "DueAmount"],
          DueDate = (DateTime) jtoken[(object) "DueDate"],
          UpdatedOn = DateTime.Now
        });
      }
    }

    public Task<int> SaveNetAssessment(StudentNetAssessment studentNetAssessment) => this._connection.InsertAsync((object) studentNetAssessment);

    public Task DeleteNetAssessment() => (Task) this._connection.QueryAsync<StudentNetAssessment>("DELETE FROM StudentNetAssessment");

    public Task<List<StudentNetAssessment>> GetNetAssessment() => this._connection.QueryAsync<StudentNetAssessment>("SELECT * FROM StudentNetAssessment");

    public async Task DownloadSemPaymentCharges(string pscsId, string strm)
    {
      foreach (JToken jtoken in await new StudentService().get_student_charges_payment_per_semester(pscsId, strm))
      {
        int num = await this.SavePaymentCharges(new StudentChargesPayment()
        {
          AccountNumber = (string) jtoken[(object) "account_number"],
          BusinessUnit = (string) jtoken[(object) "business_unit"],
          Description = (string) jtoken[(object) "description"],
          ItemAmount = (double) jtoken[(object) "item_amount"],
          ItemEffectiveDate = (DateTime) jtoken[(object) "item_effective_date"],
          ItemTypeCD = (string) jtoken[(object) "item_type_cd"],
          OrignlItemAmount = (Decimal) jtoken[(object) "orignl_item_amount"],
          PSCSId = (string) jtoken[(object) "emplid"],
          ReceiptNumber = (string) jtoken[(object) "receipt_number"],
          ReferenceDesc = (string) jtoken[(object) "reference_description"],
          Term = (string) jtoken[(object) "term"],
          UpdatedOn = DateTime.Now
        });
      }
    }

    public Task<List<StudentChargesPayment>> GetSemPaymentCharges(
      string pscsId,
      string strm)
    {
      return this._connection.QueryAsync<StudentChargesPayment>("SELECT * FROM StudentChargesPayment WHERE PSCSId=? AND Term LIKE '%" + strm + "%'", (object) pscsId);
    }

    public Task DeletePaymentCharges() => (Task) this._connection.QueryAsync<StudentChargesPayment>("DELETE FROM StudentChargesPayment");

    public Task DeletePaymentCharges(string strm) => (Task) this._connection.QueryAsync<StudentChargesPayment>("DELETE FROM StudentChargesPayment WHERE Term LIKE '%" + strm + "%'");

    public Task<int> SavePaymentCharges(StudentChargesPayment studentPayments) => this._connection.InsertAsync((object) studentPayments);

    public double GetTermBalance(string strm) => this.GetNetTuitionAmount(strm) - this.GetTotalTuitionPayment(strm);

    public double GetNetTuitionAmount(string strm)
    {
      Task<List<StudentChargesPayment>> task = this._connection.QueryAsync<StudentChargesPayment>("SELECT SUM(ItemAmount) AS ItemAmount FROM StudentChargesPayment WHERE Term=(SELECT Semester FROM StudentSemester WHERE Semester LIKE '%" + strm + "%') AND  (ItemTypeCD='C' )AND SUBSTR(AccountNumber,1,5) <> 'OPTNL' AND SUBSTR(AccountNumber,1,4)<>'SALE'");
      double netTuitionAmount = 0.0;
      foreach (StudentChargesPayment studentChargesPayment in task.Result)
        netTuitionAmount += studentChargesPayment.ItemAmount;
      return netTuitionAmount;
    }

    public double GetTotalTuitionPayment(string strm)
    {
      double num = 0.0;
      foreach (StudentChargesPayment studentChargesPayment in this.GetTuitionPaymentData(strm).Result)
        num += studentChargesPayment.ItemAmount;
      return num + Math.Abs(this.GetTotalWaivedAmount(strm).Result.Sum<StudentChargesPayment>((Func<StudentChargesPayment, double>) (x => x.ItemAmount)));
    }

    public DateTime GetRecentTransactionDate(string strm)
    {
      DateTime recentTransactionDate = DateTime.MinValue;
      foreach (StudentChargesPayment studentChargesPayment in this._connection.QueryAsync<StudentChargesPayment>("SELECT ItemEffectiveDate FROM StudentChargesPayment WHERE Term=(SELECT Semester FROM StudentSemester WHERE Semester LIKE '%" + strm + "%') ORDER BY ItemEffectiveDate DESC LIMIT 1").Result)
        recentTransactionDate = studentChargesPayment.ItemEffectiveDate;
      return recentTransactionDate;
    }

    public Task<List<StudentChargesPayment>> GetTuitionPaymentData(
      string strm)
    {
      Task<List<StudentChargesPayment>> tuitionPaymentData = this._connection.QueryAsync<StudentChargesPayment>("SELECT * FROM StudentChargesPayment WHERE (ItemTypeCD ='P' or ItemTypeCD ='R') and Term=(SELECT Semester FROM StudentSemester WHERE Semester LIKE '%" + strm + "%') AND SUBSTR(AccountNumber,1,5)<>'OPTNL' AND SUBSTR(AccountNumber,1,4)<>'SALE' ORDER BY ItemEffectiveDate DESC");
      foreach (StudentChargesPayment studentChargesPayment in tuitionPaymentData.Result)
      {
        if (studentChargesPayment.ItemTypeCD == "R")
          studentChargesPayment.ItemAmount = -Math.Abs(studentChargesPayment.ItemAmount);
        else if (studentChargesPayment.ItemTypeCD == "P")
          studentChargesPayment.ItemAmount = Math.Abs(studentChargesPayment.ItemAmount);
      }
      return tuitionPaymentData;
    }

    public Task<List<StudentChargesPayment>> GetTotalWaivedAmount(
      string strm)
    {
      Task<List<StudentChargesPayment>> totalWaivedAmount = this._connection.QueryAsync<StudentChargesPayment>("SELECT * FROM StudentChargesPayment WHERE Term=(SELECT Semester FROM StudentSemester WHERE Semester LIKE '%" + strm + "%') and   ItemTypeCD='W' and ItemAmount <> 0 ");
      foreach (StudentChargesPayment studentChargesPayment in totalWaivedAmount.Result)
        studentChargesPayment.ItemAmount = Math.Abs(studentChargesPayment.ItemAmount);
      return totalWaivedAmount;
    }

    public Task<List<StudentChargesPayment>> GetNonTuitionChargesData(
      string strm)
    {
      return this._connection.QueryAsync<StudentChargesPayment>("SELECT * FROM StudentChargesPayment WHERE Term=(SELECT Semester FROM StudentSemester WHERE Semester LIKE '%" + strm + "%') AND  ItemTypeCD='C'AND (SUBSTR(AccountNumber,1,5)='OPTNL' or SUBSTR(AccountNumber,1,4)='SALE') ORDER BY ItemEffectiveDate DESC");
    }

    public Task<List<StudentChargesPayment>> GetTuitionFeeAmount(
      string strm)
    {
      return this._connection.QueryAsync<StudentChargesPayment>("SELECT * FROM StudentChargesPayment WHERE Term=(SELECT Semester FROM StudentSemester WHERE Semester LIKE '%" + strm + "%') AND  ItemTypeCD='C'AND SUBSTR(AccountNumber,1,7)='TUTFEES' AND ItemAmount <> '0.00' ORDER BY ItemEffectiveDate DESC");
    }

    public double GetNonTuitionTotalCharges(string strm)
    {
      List<StudentChargesPayment> result = this.GetNonTuitionChargesData(strm).Result;
      double tuitionTotalCharges = 0.0;
      foreach (StudentChargesPayment studentChargesPayment in result)
        tuitionTotalCharges += studentChargesPayment.ItemAmount;
      return tuitionTotalCharges;
    }

    public Task<List<StudentChargesPayment>> GetNonTuitionPaymentData(
      string strm)
    {
      Task<List<StudentChargesPayment>> tuitionPaymentData = this._connection.QueryAsync<StudentChargesPayment>("SELECT * FROM StudentChargesPayment WHERE (ItemTypeCD ='P' or ItemTypeCD ='R' ) AND Term LIKE '%" + strm + "%' AND (SUBSTR(AccountNumber,1,5)='OPTNL' OR SUBSTR(AccountNumber,1,4)='SALE') ORDER BY ItemEffectiveDate DESC");
      foreach (StudentChargesPayment studentChargesPayment in tuitionPaymentData.Result)
      {
        if (studentChargesPayment.ItemTypeCD == "R")
          studentChargesPayment.ItemAmount = -Math.Abs(studentChargesPayment.ItemAmount);
        else if (studentChargesPayment.ItemTypeCD == "P")
          studentChargesPayment.ItemAmount = Math.Abs(studentChargesPayment.ItemAmount);
      }
      return tuitionPaymentData;
    }

    public double GetNonTuitionTotalPayment(string strm)
    {
      List<StudentChargesPayment> result = this.GetNonTuitionPaymentData(strm).Result;
      double tuitionTotalPayment = 0.0;
      foreach (StudentChargesPayment studentChargesPayment in result)
        tuitionTotalPayment += studentChargesPayment.ItemAmount;
      return tuitionTotalPayment;
    }

    public async Task DownloadStudentCurrentDue(string pscsid)
    {
      try
      {
        foreach (JToken jtoken in await new StudentService().get_student_current_due(pscsid))
        {
          int num = await this.SaveStudentCurrentDue(new StudentCurrentDue()
          {
            dueDate = (DateTime) jtoken[(object) "due_date"],
            dueAmount = (float) jtoken[(object) "due_amt"],
            appliedAmount = (float) jtoken[(object) "applied_amt"],
            TermStartdate = (DateTime) jtoken[(object) "term_start_date"],
            TermEndDate = (DateTime) jtoken[(object) "term_end_date"],
            schoolTerm = (string) jtoken[(object) "school_term"],
            studTerm = (string) jtoken[(object) "student_term"],
            currentDue = (float) jtoken[(object) "current_due"]
          });
        }
      }
      catch
      {
      }
    }

    public Task<int> SaveStudentCurrentDue(StudentCurrentDue studentCurrentDue) => this._connection.InsertAsync((object) studentCurrentDue);

    public Task<List<StudentCurrentDue>> GetStudentCurrentDue() => this._connection.QueryAsync<StudentCurrentDue>("SELECT * FROM StudentCurrentDue");

    public Task DeleteStudentCurrentDue() => (Task) this._connection.QueryAsync<StudentCurrentDue>("DELETE FROM StudentCurrentDue");

    public async Task DownloadDueDetails(string pscsID, string term, string level)
    {
      foreach (JToken dueDetail in await new StudentService().get_due_details(pscsID, term, level))
      {
        int num = await this.SaveDueDetails(new StudentDueDetails()
        {
          AppliedAmount = (float) dueDetail[(object) "AppliedAmount"],
          DueAmount = (float) dueDetail[(object) "DueAmount"],
          DueDate = (DateTime) dueDetail[(object) "DueDate"],
          pscsID = pscsID
        });
      }
    }

    public Task<int> SaveDueDetails(StudentDueDetails studentDueDetails) => this._connection.InsertAsync((object) studentDueDetails);

    public Task<List<StudentDueDetails>> GetDueDetails() => this._connection.QueryAsync<StudentDueDetails>("SELECT * FROM StudentDueDetails");

    public Task DeleteDueDetails() => (Task) this._connection.QueryAsync<StudentDueDetails>("DELETE FROM StudentDueDetails");

    public async Task DownloadAllChargesDueDate(string pscsId)
    {
      foreach (JToken jtoken in await new StudentService().get_student_charges_due_date(pscsId))
      {
        int num = await this.SaveChargesDueDate(new StudentChargesDueDate()
        {
          DueAmount = (Decimal) jtoken[(object) "due_amount"],
          DueDate = (DateTime) jtoken[(object) "due_date"],
          PSCSId = (string) jtoken[(object) "emplid"],
          Term = (string) jtoken[(object) "term"],
          UpdatedOn = DateTime.Now
        });
      }
    }

    public async Task DownloadSemChargesDueDate(string pscsId, string strm)
    {
      foreach (JToken jtoken in await new StudentService().get_student_charges_due_date_per_semester(pscsId, strm))
      {
        int num = await this.SaveChargesDueDate(new StudentChargesDueDate()
        {
          DueAmount = (Decimal) jtoken[(object) "due_amount"],
          DueDate = (DateTime) jtoken[(object) "due_date"],
          PSCSId = (string) jtoken[(object) "emplid"],
          Term = (string) jtoken[(object) "term"],
          UpdatedOn = DateTime.Now
        });
      }
    }

    public Task DeleteChargesDueDate() => (Task) this._connection.QueryAsync<StudentChargesDueDate>("DELETE FROM StudentChargesDueDate");

    public Task DeleteChargesDueDate(string strm) => (Task) this._connection.QueryAsync<StudentChargesDueDate>("DELETE FROM StudentChargesDueDate WHERE Term LIKE '%" + strm + "%'");

    public Task<int> SaveChargesDueDate(StudentChargesDueDate studentChargesDue) => this._connection.InsertAsync((object) studentChargesDue);

    public Task<List<StudentChargesDueDate>> GetChargesDueData(
      string strm)
    {
      return this._connection.QueryAsync<StudentChargesDueDate>("SELECT * FROM StudentChargesDueDate WHERE Term LIKE '%" + strm + "%' ORDER BY DueDate");
    }

    public async Task DownloadOSFDetails(string pscsId, string strm)
    {
      foreach (JToken jtoken in await new StudentService().get_osf_details_shs(pscsId, strm))
      {
        int num = await this.SaveOSFDetails(new OSFDetails()
        {
          det_fee_code = (string) jtoken[(object) "det_fee_code"],
          det_item_amount = (string) jtoken[(object) "det_item_amount"],
          fee_code = (string) jtoken[(object) "fee_code"],
          item_amount = (string) jtoken[(object) "item_amount"],
          pscs_id = (string) jtoken[(object) "pscs_id"],
          strm = (string) jtoken[(object) nameof (strm)]
        });
      }
    }

    public Task<int> SaveOSFDetails(OSFDetails osfDetails) => this._connection.InsertAsync((object) osfDetails);

    public Task<List<OSFDetails>> GetOSFDetails(string strm) => this._connection.QueryAsync<OSFDetails>("SELECT * FROM OSFDetails WHERE strm LIKE '%" + strm + "%'");

    public Task DeleteOSFDetails() => (Task) this._connection.QueryAsync<OSFDetails>("DELETE FROM OSFDetails");

    public Task DeleteOSFDetails(string strm) => (Task) this._connection.QueryAsync<OSFDetails>("DELETE FROM OSFDetails WHERE strm LIKE '%" + strm + "%'");

    public async Task DownloadTuitionMiscDetails(string pscsId, string strm)
    {
      foreach (JToken tuitionMiscDetail in await new StudentService().get_tuition_misc_details(pscsId, strm))
      {
        int num = await this.SaveTuitionMiscDetails(new MiscDetails()
        {
          fee_code = (string) tuitionMiscDetail[(object) "fee_code"],
          item_amount = (string) tuitionMiscDetail[(object) "item_amount"],
          pscs_id = (string) tuitionMiscDetail[(object) "pscs_id"],
          strm = (string) tuitionMiscDetail[(object) nameof (strm)]
        });
      }
    }

    public Task<int> SaveTuitionMiscDetails(MiscDetails miscDetails) => this._connection.InsertAsync((object) miscDetails);

    public Task<List<MiscDetails>> GetTuitionMiscDetails(string strm) => this._connection.QueryAsync<MiscDetails>("SELECT * FROM MiscDetails WHERE strm LIKE '%" + strm + "%'");

    public Task DeleteTuitionMiscDetails() => (Task) this._connection.QueryAsync<MiscDetails>("DELETE FROM MiscDetails");

    public Task DeleteTuitionMiscDetails(string strm) => (Task) this._connection.QueryAsync<MiscDetails>("DELETE FROM MiscDetails WHERE strm LIKE '%" + strm + "%'");

    public async Task DownloadStudentSettings(string pscsId)
    {
      JObject studentSettings = await new StudentService().get_student_settings(pscsId);
      double num1 = (double) studentSettings["past_due_amount"];
      int num2 = await this.SaveSettings(new StudentSettings()
      {
        PastDue = num1,
        IsGradeViewable = num1 <= 0.0,
        PSCSId = (string) studentSettings["student_id"],
        LastSync = DateTime.Now
      });
    }

    public Task DeleteSettings() => (Task) this._connection.QueryAsync<StudentSettings>("DELETE FROM StudentSettings");

    public Task<int> SaveSettings(StudentSettings studentSettings) => this._connection.InsertAsync((object) studentSettings);

    public double HasPastDue()
    {
      double num = 0.0;
      foreach (StudentSettings studentSettings in this._connection.QueryAsync<StudentSettings>("SELECT * FROM StudentSettings").Result)
        num = studentSettings.PastDue;
      return num;
    }
  }
}
