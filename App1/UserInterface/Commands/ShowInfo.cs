using App1.UserInterface.Commands.Interfaces;

namespace App1.UserInterface.Commands
{
    class ShowInfo : Command
    {
        public void execute()
        {
            Console.WriteLine("��������� ��� ��� �������:\n'�������' - �������� ������� ��� ����� � ��������;\n" +
                "'�����' - �������� ��������� ����� ����� �� �������� �����/��������;\n" +
                "'��������' - �������� �������� ������������ ���� � �������;\n" +
                "'�������' - �������� ������� ������������ ���� �� ��������;\n" +
                "'�����' - �������� ������ ���������;\n");
        }
    }
}