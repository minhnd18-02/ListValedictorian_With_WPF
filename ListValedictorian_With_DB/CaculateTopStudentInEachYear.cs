using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ListValedictorian_With_DB
{
    public class CaculateTopStudentInEachYear
    {
        private readonly FileCsvContext _context;
        public CaculateTopStudentInEachYear()
        {
            _context = new FileCsvContext();
        }
        public List<DataStatistics> CaculateValedictorianWithBlockA(int year)
        {
            var mathScore = _context.MarkReports.Where(x => x.Year == year && x.Toan.HasValue
            && x.Ly.HasValue && x.Hoa.HasValue).
                OrderByDescending(totalScore => totalScore.Toan + totalScore.Hoa + totalScore.Ly).
                Select(x => new DataStatistics
                {
                    Sbd = x.Sbd,
                    Score01 = x.Toan,
                    Score02 = x.Ly,
                    Score03 = x.Hoa,
                    TotalScore = x.Hoa + x.Ly + x.Toan,
                    Subjects = "Toan, Ly, Hoa"
                }).ToList();
            if (mathScore == null)
            {
                MessageBox.Show("No top student in this year");
            }
            var highScore = mathScore.Max(x => x.TotalScore);
            var topStudent = mathScore.Where(x => x.TotalScore == highScore).ToList();
            return topStudent;
        }

        public List<DataStatistics> CaculateValedictorianWithBlockB(int year)
        {
            var mathScore = _context.MarkReports.Where(x => x.Year == year && x.Toan.HasValue
            && x.Sinh.HasValue && x.Hoa.HasValue).
                OrderByDescending(totalScore => totalScore.Toan + totalScore.Hoa + totalScore.Sinh).
                Select(x => new DataStatistics
                {
                    Sbd = x.Sbd,
                    Score01 = x.Toan,
                    Score02 = x.Sinh,
                    Score03 = x.Hoa,
                    TotalScore = x.Hoa + x.Sinh + x.Toan,
                    Subjects = "Toan, Sinh, Hoa"
                }).ToList();
            if (mathScore == null)
            {
                MessageBox.Show("No top student in this year");
            }
            var highScore = mathScore.Max(x => x.TotalScore);
            var topStudent = mathScore.Where(x => x.TotalScore == highScore).ToList();
            return topStudent;
        }

        public List<DataStatistics> CaculateValedictorianWithBlockC(int year)
        {
            var mathScore = _context.MarkReports.Where(x => x.Year == year && x.Van.HasValue
            && x.Lichsu.HasValue && x.Dialy.HasValue).
                OrderByDescending(totalScore => totalScore.Van + totalScore.Lichsu + totalScore.Dialy).
                Select(x => new DataStatistics
                {
                    Sbd = x.Sbd,
                    Score01 = x.Van,
                    Score02 = x.Lichsu,
                    Score03 = x.Dialy,
                    TotalScore = x.Van + x.Lichsu + x.Dialy,
                    Subjects = "Van, Su, Dia"
                }).ToList();
            if (mathScore == null)
            {
                MessageBox.Show("No top student in this year");
            }
            var highScore = mathScore.Max(x => x.TotalScore);
            var topStudent = mathScore.Where(x => x.TotalScore == highScore).ToList();
            return topStudent;
        }

        public List<DataStatistics> CaculateValedictorianWithBlockD1(int year)
        {
            var mathScore = _context.MarkReports.Where(x => x.Year == year && x.Van.HasValue
            && x.Toan.HasValue && x.Ngoaingu.HasValue).
                OrderByDescending(totalScore => totalScore.Van + totalScore.Toan + totalScore.Ngoaingu).
                Select(x => new DataStatistics
                {
                    Sbd = x.Sbd,
                    Score01 = x.Van,
                    Score02 = x.Toan,
                    Score03 = x.Ngoaingu,
                    TotalScore = x.Van + x.Toan + x.Ngoaingu,
                    Subjects = "Van, Toan, Ngoaingu"
                }).ToList();
            if (mathScore == null)
            {
                MessageBox.Show("No top student in this year");
            }
            var highScore = mathScore.Max(x => x.TotalScore);
            var topStudent = mathScore.Where(x => x.TotalScore == highScore).ToList();
            return topStudent;
        }

        public List<DataStatistics> CaculateValedictorianWithBlockA1(int year)
        {
            var mathScore = _context.MarkReports.Where(x => x.Year == year && x.Ly.HasValue
            && x.Toan.HasValue && x.Ngoaingu.HasValue).
                OrderByDescending(totalScore => totalScore.Ly + totalScore.Toan + totalScore.Ngoaingu).
                Select(x => new DataStatistics
                {
                    Sbd = x.Sbd,
                    Score01 = x.Ly,
                    Score02 = x.Toan,
                    Score03 = x.Ngoaingu,
                    TotalScore = x.Ly + x.Toan + x.Ngoaingu,
                    Subjects = "Ly, Toan, Ngoaingu"
                }).ToList();
            if (mathScore == null)
            {
                MessageBox.Show("No top student in this year");
            }
            var highScore = mathScore.Max(x => x.TotalScore);
            var topStudent = mathScore.Where(x => x.TotalScore == highScore).ToList();
            return topStudent;
        }
    }
}
