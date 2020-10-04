using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace MemberManager
{
    public class Repository
    {
        private const string fileName = "Vereinsmitglieder.csv";

        private static Repository instance;

        List<Member> members;

        private Repository()
        {
            members = new List<Member>();
            LoadMembersFromCsv();
        }

        public static Repository GetInstance()
        {
            if (instance == null)
                instance = new Repository();

            return instance;
        }

        private void LoadMembersFromCsv()
        {
            string[][] memberCsv = fileName.ReadStringMatrixFromCsv(true);
            members = memberCsv.GroupBy(part => new {
                Id = Convert.ToInt32(part[0]),
                FirstName = part[1],
                LastName = part[2],
                Birthdate = part[3],
            }).Select(x =>
                new Member
                {
                    Id = x.Key.Id,
                    FirstName = x.Key.FirstName,
                    LastName = x.Key.LastName,
                    Birthdate = x.Key.Birthdate,
                }).ToList();
        }

        public void AddMember(Member member)
        {
            members.Add(member);
        }

        public void RemoveMember(Member member)
        {
            foreach(Member m in members)
            {
                if(m.Id == member.Id)
                {
                    members.Remove(m);
                    return;
                }
            }
        }

        public void EditMember(Member selectedMember)
        {
            RemoveMember(selectedMember);
            AddMember(selectedMember);
        }

        public List<Member> GetAllMember()
        {
            return members.OrderBy(x => x.LastName).ToList();
        }
    }
}
