using ComplexManagement_CleanArchitecture.Entities;
using ComplexManagement_CleanArchitecture.Service.Complexes.Contracts;
using ComplexManagement_CleanArchitecture.Service.Complexes.Contracts.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.EFPresistence.Complexes
{
    public class EFComplexRepository : ComplexRepository
    {
        private readonly DbSet<Complex> _complex;
        public EFComplexRepository(EFDataContext context)
        {
            _complex = context.Set<Complex>();
        }

        public void Add(Complex complex)
        {
            _complex.Add(complex);
        }

        public bool BlockDuplicateNameByComplexId(int complexId, string name)
        {
            return _complex.Any(_ => _.Blocks.Any(_ => _.Name == name));
        }

        public bool FindComplexById(int complexId)
        {
            return _complex.Any(_ => _.Id == complexId);
        }

        public List<GetAllComplexWithBlockDetailsDto>
            GetAllComplexesWithBlockDetails(string? name)
        {
            List<GetAllComplexWithBlockDetailsDto> result =
                new List<GetAllComplexWithBlockDetailsDto>();

            int counter = 1;
            if (name != null)
            {
                foreach (var item in _complex.Include(_ => _.Blocks))
                {
                    result.Add(new GetAllComplexWithBlockDetailsDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Blocks = item.Blocks.Where(b => b.Name.Contains(name))
                        .Select(_ => new BlockDetailsDto
                        {
                            BlockNumber = counter++,
                            UnitCount = _.UnitCount
                        }).ToList()
                    });
                }
                return result;
            }

            foreach (var item in _complex.Include(_ => _.Blocks))
            {
                result.Add(new GetAllComplexWithBlockDetailsDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Blocks = item.Blocks
                    .Select(_ => new BlockDetailsDto
                    {
                        BlockNumber = counter++,
                        UnitCount = _.UnitCount
                    }).ToList()
                });
            }
            return result;
        }

        public List<GetAllComplexesWithUnitCount> GetAllComplexesWithUnitCount(ComplexSearchDto dto)
        {
            var result = _complex.Select(_ => new GetAllComplexesWithUnitCount
            {
                Id = _.Id,
                Name = _.Name,
                RegisteredUnits = _.Blocks.SelectMany(_ => _.Units).Count(),
                RemainingUnits = _.UnitCount
                - _.Blocks.SelectMany(_ => _.Units).Count()
            });

            result = ComplexSearch(result, dto);

            return result.ToList();
        }

        public int GetComplexBlocksUnitCountByComplexId(int complexId)
        {
            return _complex
                .Where(_ => _.Id == complexId)
                .Select(_ => _.Blocks
                .Sum(_ => _.UnitCount))
                .FirstOrDefault();

        }

        public Complex? GetComplexById(int complexId)
        {
            return _complex.FirstOrDefault(_ => _.Id == complexId);
        }

        public int GetComplexUnitCountById(int complexId)
        {
            return _complex
                .Where(_ => _.Id == complexId)
                .Select(_ => _.UnitCount)
                .FirstOrDefault();
        }

        public Complex? GetComplexWithBlocksById(int complexId)
        {
            return _complex.Where(_ => _.Id == complexId)
                .Include(_ => _.Blocks).FirstOrDefault();
        }

        public bool IsDuplicatedBlockNameForEditName(int blockId, string name)
        {
            return _complex
                .Any(_ => _.Blocks
                .Any(_ => _.Name == name
                && _.Id != blockId));
        }

        public void UpdateComplexUnitCount(Complex complex)
        {
            _complex.Update(complex);
        }

        private IQueryable<GetAllComplexesWithUnitCount>
            ComplexSearch(IQueryable<GetAllComplexesWithUnitCount>
            complexes, ComplexSearchDto dto)
        {
            if (dto.Name != null)
            {
                return complexes.Where(_ => _.Name.Contains(dto.Name));
            }

            if (dto.Id != null)
            {
                return complexes.Where(_ => _.Id == dto.Id);
            }

            return complexes;
        }


    }
}
