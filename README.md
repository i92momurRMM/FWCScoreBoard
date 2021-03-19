# Football World Cup Score Board
Implementation of the Football World Cup Score Board as a library with TDD.

## Notes for tests

I have followed Classical or Detroit-school TDD (Inside-Out).

Unit tests have been done to build the code and integration tests to check the operations as a whole. 

In my opinion, tests are a form of 'executable documentation with TDD'. I emphasise that tests should be readable and understandable by anyone who does not know the application. For this reason, I use my own Test-Support Class:

Including a template for practicing TDD and write any unit, functional or integration tests following a Given-When-Then (optional async) approach with xUnit framework.

    public abstract class Given_When_Then_Test
        : IDisposable
    {
        protected Given_When_Then_Test()
        {
            Setup();
        }

        private void Setup()
        {
            Given();
            When();
        }

        protected abstract void Given();

        protected abstract void When();

        public void Dispose()
        {
            Cleanup();
        }

        protected virtual void Cleanup()
        {
        }
    }

	On the other hand, all associated test classes will be packed into a static class, which makes it easy to view in the test explorer.
