using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Core.Interfaces;
using Core.Specification;

namespace Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {  public BaseSpecification(){
    
        }

        public BaseSpecification(Expression<Func<T,bool>> criteria){
               Criteria = criteria;
        }
         public Expression<Func<T,bool>> Criteria {get;}
       public List<Expression<Func<T,object>>> Includes {get;} = new List<Expression<Func<T, object>>>();
         
        protected void AddInclude(Expression<Func<T,object>> includeExpression){
            Includes.Add(includeExpression);
         }

         public Expression<Func<T,object>> OrderBy{
               get;
               private set;
         }
           public Expression<Func<T,object>> OrderByDecending{
            get;
            private set;
         }
         protected void AddOrderBy(Expression<Func<T,object>> orderByExpression){
            OrderBy = orderByExpression;
         }

                 protected void AddOrderByDecending(Expression<Func<T,object>> orderByDscExpression){
            OrderByDecending = orderByDscExpression;
         }
          public int Take{get;private set;}

          public int Skip{get; private set;}


          public bool isPagingEnable{get; private set;}

          protected void ApplyPaging(int  skip,int take){
            Skip = skip;
            Take = take;
            isPagingEnable = true;
          }

    }
}