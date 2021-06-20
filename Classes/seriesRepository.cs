using System;
using System.Collections.Generic;
using SeriesRegister.Interfaces;

namespace SeriesRegister.Classes
{
    public class seriesRepository: IRepository<series>
    {
        private List<series> seriesList = new List<series>();
        
        public List<series> list(){
            return seriesList;
        }

        public void insert(series entity){
            seriesList.Add(entity);
        }

        public void update(int id, series entity){
            seriesList[id] = entity;
        }

        public void delete(int id){
            seriesList[id].Delete();
        }

        public series getById(int id){
            return seriesList[id];
        }

        public int nextId(){
            return seriesList.Count;
        }
    }
}