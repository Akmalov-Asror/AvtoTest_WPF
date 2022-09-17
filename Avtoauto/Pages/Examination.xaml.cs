using Avtoauto.Databases;
using Avtoauto.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace Avtoauto.Pages;

public partial class Examination : Page
{
    private Ticket CurrentTicket;
    private int currentQuestionIndex;

    public Examination(int? currentTicketIndex = null)
    {
        InitializeComponent();
        CurrentTicket = Database.Db.TicketDb.CreateTicket();
        QuestionIndexButton();
        ShowQuestion();

        if (currentTicketIndex != null)
        {
            Title.Content = $"Ticket{currentTicketIndex}";
        }
    }

    private void QuestionIndexButton()
    {
        for (int i = 0; i < CurrentTicket.QuestionsCount; i++)
        {
            var button = new Button()
            {
                Height = 30,
                Width = 30,
                Content = i + 1,
                Tag = i,
            };
            button.Click += QuestionIndexButtonClicked;
            QuestionIndexButtonPanel.Children.Add(button);
        }
    }

    private void QuestionIndexButtonClicked(object sender, RoutedEventArgs e)
    {
        ChoicePanel.Children.Clear();
        var button = sender as Button;
        currentQuestionIndex = (int)button.Tag;
        ShowQuestion();
    }

    public void GenerationChoiceButton(QuestionEntity question)
    {
        var buttonsCount = question.Choices;
        for (int i = 0; i < buttonsCount.Count; i++)
        {
            var button = new Button();
            button.Width = 300;
            button.Height = 50;
            button.FontSize = 14;
            button.Content = buttonsCount[i].Text;
            button.Click += ChoiceButtonClick;
            button.Tag = i;
            ChoicePanel.Children.Add(button);
        }
    }



    

    public void ShowImage(string imagename)
    {
        QuestionImage.Source = new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "Images", $"{imagename}.png")));
    }

    private void ShowQuestion()
    {
        var question = CurrentTicket.Questions[currentQuestionIndex];
        ShowImage(question.Media.Name);
        QuestionText.Text = question.Question;
        GenerationChoiceButton(question);
    }
     
    private void ChoiceButtonClick(object sender,RoutedEventArgs e)
    {
        var button = sender as Button;
        var choiceIndex = (int)button.Tag;
        MessageBox.Show(choiceIndex + " ni tanladi");
    }

    public void Close_Button(object sender,RoutedEventArgs e)
    {
        MainWindow.Instance.MenuFrame.Navigate(new MainMenu());
    }
}
