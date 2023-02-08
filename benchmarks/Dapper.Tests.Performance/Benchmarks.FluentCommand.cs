using System.ComponentModel;
using System.Linq;

using BenchmarkDotNet.Attributes;

using FluentCommand;
using FluentCommand.Extensions;

using ServiceStack;

namespace Dapper.Tests.Performance
{
    [Description("Fluent")]
    public class FluentCommandBenchmarks : BenchmarkBase
    {
        [GlobalSetup]
        public void Setup()
        {
            BaseSetup();
        }

        [Benchmark(Description = "Query<T> (Factory)")]
        public Post QueryFactory()
        {
            Step();

            var session = new DataSession(_connection, false);
            var sql = "select * from Posts where Id = @Id";

            return session.Sql(sql)
                .Parameter("@Id", i)
                .Query(r => new Post
                {
                    Id = r.GetInt32("Id"),
                    Text = r.GetStringNull("Text"),
                    CreationDate = r.GetDateTime("CreationDate"),
                    LastChangeDate = r.GetDateTime("LastChangeDate"),
                    Counter1 = r.GetInt32Null("Counter1"),
                    Counter2 = r.GetInt32Null("Counter2"),
                    Counter3 = r.GetInt32Null("Counter3"),
                    Counter4 = r.GetInt32Null("Counter4"),
                    Counter5 = r.GetInt32Null("Counter5"),
                    Counter6 = r.GetInt32Null("Counter6"),
                    Counter7 = r.GetInt32Null("Counter7"),
                    Counter8 = r.GetInt32Null("Counter8"),
                    Counter9 = r.GetInt32Null("Counter9"),
                })
                .First();
        }

        [Benchmark(Description = "QueryPost (Generated)")]
        public Post QueryPost()
        {
            Step();

            var session = new DataSession(_connection, false);
            var sql = "select * from Posts where Id = @Id";

            return session.Sql(sql)
                .Parameter("@Id", i)
                .QueryPost()
                .First();
        }

        [Benchmark(Description = "QuerySingle<T> (Factory)")]
        public Post QuerySingleFactory()
        {
            Step();

            var session = new DataSession(_connection, false);
            var sql = "select * from Posts where Id = @Id";

            return session.Sql(sql)
                .Parameter("@Id", i)
                .QuerySingle(r => new Post
                {
                    Id = r.GetInt32("Id"),
                    Text = r.GetStringNull("Text"),
                    CreationDate = r.GetDateTime("CreationDate"),
                    LastChangeDate = r.GetDateTime("LastChangeDate"),
                    Counter1 = r.GetInt32Null("Counter1"),
                    Counter2 = r.GetInt32Null("Counter2"),
                    Counter3 = r.GetInt32Null("Counter3"),
                    Counter4 = r.GetInt32Null("Counter4"),
                    Counter5 = r.GetInt32Null("Counter5"),
                    Counter6 = r.GetInt32Null("Counter6"),
                    Counter7 = r.GetInt32Null("Counter7"),
                    Counter8 = r.GetInt32Null("Counter8"),
                    Counter9 = r.GetInt32Null("Counter9"),
                });
        }

        [Benchmark(Description = "QuerySinglePost (Generated)")]
        public Post QuerySinglePost()
        {
            Step();

            var session = new DataSession(_connection, false);
            var sql = "select * from Posts where Id = @Id";

            return session.Sql(sql)
                .Parameter("@Id", i)
                .QuerySinglePost();
        }
    }
}
