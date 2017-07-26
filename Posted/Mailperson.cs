using System.Threading.Tasks;

namespace Posted
{
    public interface MailPerson
    {
        void Send(Envelope envelope);
        Task SendAsync(Envelope envelope);
    }
}
