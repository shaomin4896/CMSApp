using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagementAPI.Models;
using CaseManagementApp.Models.ControlItems;

namespace CaseManagementApp.Extensions
{
    public static class FormatHelper
    {
        public static List<TestRecord> ToTestRecords(this CmsCase cmsCase)
        {
            List<TestRecord> testRecords = new List<TestRecord>();

            cmsCase.BloodPressureTests.ForEach(x =>
            {
                TestRecord? testRecord = testRecords.FirstOrDefault(t => t.TestDate == x.TestDate);
                if (testRecord == null)
                {
                    testRecord = new()
                    {
                        Systolic = x.Systolic,
                        Diastolic = x.Diastolic,
                        TestDate = (DateTime)x.TestDate,
                        CmsCase = cmsCase
                    };
                    testRecords.Add(testRecord);
                }
                else
                {
                    testRecord.Systolic = x.Systolic;
                    testRecord.Diastolic = x.Diastolic;
                }
            });

            cmsCase.BloodTests.ForEach(x =>
            {
                TestRecord? testRecord = testRecords.FirstOrDefault(t => t.TestDate == x.TestDate);
                if (testRecord == null)
                {
                    testRecord = new()
                    {
                        HBAIC = x.HBAIC,
                        BloodSugarBeforeMeal = x.BloodSugarBeforeMeal,
                        TG = x.TG,
                        Creatinine = x.Creatinine,
                        TestDate = (DateTime)x.TestDate,
                        CmsCase = cmsCase
                    };
                    testRecords.Add(testRecord);
                }
                else
                {
                    testRecord.HBAIC = x.HBAIC;
                    testRecord.BloodSugarBeforeMeal = x.BloodSugarBeforeMeal;
                    testRecord.TG = x.TG;
                    testRecord.Creatinine = x.Creatinine;
                }
            });

            cmsCase.UrineTests.ForEach(x => 
            {
                TestRecord? testRecord = testRecords.FirstOrDefault(t => t.TestDate == x.TestDate);
                if (testRecord == null)
                {
                    testRecord = new()
                    {
                        DidRoutine = x.DidRoutine,
                        LDL = x.LDL,
                        Microprotein = x.Microprotein,
                        TestDate = (DateTime)x.TestDate,
                        CmsCase = cmsCase
                    };
                    testRecords.Add(testRecord);
                }
                else
                {
                    testRecord.DidRoutine = x.DidRoutine;
                    testRecord.LDL = x.LDL;
                    testRecord.Microprotein = x.Microprotein;           
                }
            });

            cmsCase.FootTests.ForEach(x => 
            {
                TestRecord? testRecord = testRecords.FirstOrDefault(t => t.TestDate == x.TestDate);
                if (testRecord == null)
                {
                    testRecord = new()
                    {
                        IsLeftNormal = x.IsLeftNormal,
                        IsRightNormal = x.IsRightNormal,
                        TestDate = (DateTime)x.TestDate,
                        CmsCase = cmsCase
                    };
                    testRecords.Add(testRecord);
                }
                else
                {
                    testRecord.IsLeftNormal = x.IsLeftNormal;
                    testRecord.IsRightNormal = x.IsRightNormal;
                }
            });

            cmsCase.EyeTests.ForEach(x => 
            {
                TestRecord? testRecord = testRecords.FirstOrDefault(t => t.TestDate == x.TestDate);
                if (testRecord == null)
                {
                    testRecord = new()
                    {
                        IsNormal = x.IsNormal,
                        TestDate = (DateTime)x.TestDate,
                        CmsCase = cmsCase
                    };
                    testRecords.Add(testRecord);
                }
                else
                {
                    testRecord.IsNormal = x.IsNormal;
                }
            });

            cmsCase.EyeTests.ForEach(x => 
            {
                TestRecord? testRecord = testRecords.FirstOrDefault(t => t.TestDate == x.TestDate);
                if (testRecord == null)
                {
                    testRecord = new()
                    {
                        IsNormal = x.IsNormal,
                        TestDate = (DateTime)x.TestDate,
                        CmsCase = cmsCase
                    };
                    testRecords.Add(testRecord);
                }
                else
                {
                    testRecord.IsNormal = x.IsNormal;
                }
            });

            cmsCase.HealthHistories.ForEach(x => 
            {
                TestRecord? testRecord = testRecords.FirstOrDefault(t => t.TestDate == x.TraceDate);
                if (testRecord == null)
                {
                    testRecord = new()
                    {
                        HealthHistory = x,
                        TestDate = (DateTime)x.TraceDate,
                        CmsCase = cmsCase
                    };
                    testRecords.Add(testRecord);
                }
                else
                {
                    testRecord.HealthHistory = x;
                }
            });

            cmsCase.PatientSelfHistories.ForEach(x => 
            {
                TestRecord? testRecord = testRecords.FirstOrDefault(t => t.TestDate == x.BloodPressureTest.TestDate);
                if (testRecord == null)
                {
                    testRecord = new()
                    {
                        BloodSugarBeforeMeal = x.BloodTest.BloodSugarBeforeMeal,
                        Systolic = x.BloodPressureTest.Systolic,
                        Diastolic = x.BloodPressureTest.Diastolic,
                        IsLeftNormal = x.FootTest.IsLeftNormal,
                        IsRightNormal = x.FootTest.IsRightNormal,
                        TestDate = (DateTime)x.BloodPressureTest.TestDate,
                        CmsCase = cmsCase
                    };
                    testRecords.Add(testRecord);
                }
                else
                {
                    testRecord.BloodSugarBeforeMeal = x.BloodTest.BloodSugarBeforeMeal;
                    testRecord.Systolic = x.BloodPressureTest.Systolic;
                    testRecord.Diastolic = x.BloodPressureTest.Diastolic;
                    testRecord.IsLeftNormal = x.FootTest.IsLeftNormal;
                    testRecord.IsRightNormal = x.FootTest.IsRightNormal;
                }
            });

            return testRecords;
        }
    }
}