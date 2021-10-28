﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public void SkillAddBL(Skill skill)
        {
            _skillDal.Insert(skill);
        }

        public void SkillDelete(Skill skill)
        {
            _skillDal.Update(skill);
        }

        public void SkillUpdate(Skill skill)
        {
            _skillDal.Update(skill);
        }

        public Skill GetByID(int id)
        {
            return _skillDal.Get(x => x.SkillId == id);
        }

        public List<Skill> GetList()
        {
            return _skillDal.List();
        }
    }
}