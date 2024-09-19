﻿using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Data
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ExampleDbContext _context;
        
        public MedicoRepository(ExampleDbContext context)
        {
            _context = context;
        }

        public void AddMedico(Medico entity)
        {
            _context.Medicos.Add(entity);
            _context.SaveChanges();
        }

        public List<Medico> GetMedicos()
        {
            return _context.Medicos.ToList();
        }

        public List<Medico> GetMedicosByEspecialidad(Especialidad especialidad)
        {
            return _context.Medicos.Where(medico => medico.Especialidad == especialidad).ToList();
        }
    }
}
