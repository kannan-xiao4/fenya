using Interface;
using Model;
using ValueObject;

namespace ViewModel
{
    public class RankingViewModel : IRankingViewModel
    {
        private Ranking Model;

        public RankingViewModel(Ranking model)
        {
            Model = model;
        }
    }
}