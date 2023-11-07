﻿using My_Media_Collection.Enums;
using My_Media_Collection.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Microsoft.UI.Xaml.Input;

namespace My_Media_Collection.ViewModels
{
	public class MainViewModel : BindableBase
	{
		private string selectedMedium;
		private ObservableCollection<MediaItem> items;
		private ObservableCollection<MediaItem> allItems; // show all items in the Combobox filter
		private IList<string> mediums;         // list of mediums for using in Combobox filter
		private MediaItem selectedMediaItem;   // 
		private int additionalItemCount = 1;   // a temporary variable we will use to track how many new items we have added to the list

		public MainViewModel() 
		{
			PopulateData();
			DeleteCommand = new RelayCommand(DeleteItem, CanDeleteItem);
			// No CanExecute param is needed for this command
			// because you can always add or edit items.
			AddEditCommand = new RelayCommand(AddOrEditItem);
		}

		public string SelectedMedium
		{	get { return selectedMedium; } 
			set 
				{ 
					SetProperty(ref selectedMedium, value);

					Items.Clear();

					foreach (var item in allItems)
					{
						if (string.IsNullOrWhiteSpace(selectedMedium) ||
							selectedMedium == "All" ||
							selectedMedium == item.MediaType.ToString())
						{
							Items.Add(item);
						}
					}
				} 
		}

		public ObservableCollection<MediaItem> Items
		{ get { return items; } set { SetProperty(ref items, value); } }

		public ObservableCollection<MediaItem> AllItems
		{ get { return allItems; } set { SetProperty(ref allItems, value); } }

		public IList<string> Mediums
		{ get { return this.mediums; } set { SetProperty(ref mediums, value); } }

		public MediaItem SelectedMediaItem
		{
			get => selectedMediaItem;
			set
			{
				SetProperty(ref selectedMediaItem, value);
				((RelayCommand)DeleteCommand).RaiseCanExecuteChanged();
			}
		}

		public void PopulateData()
		{
			var cd = new MediaItem
			{
				Id = 1,
				Name = "Classical Favorites",
				MediaType = ItemType.Music,
				MediumInfo = new Medium { Id = 1, MediaType = ItemType.Music, Name = "CD" }
			};

			var book = new MediaItem
			{
				Id = 2,
				Name = "Classic Fairy Tales",
				MediaType = ItemType.Book,
				MediumInfo = new Medium { Id = 2, MediaType = ItemType.Book, Name = "Book" }
			};

			var bluRay = new MediaItem
			{
				Id = 3,
				Name = "The Mummy",
				MediaType = ItemType.Video,
				MediumInfo = new Medium { Id = 3, MediaType = ItemType.Video, Name = "Blu Ray" }
			};

			items = new ObservableCollection<MediaItem>
			{
				cd,
				book,
				bluRay
			};

			allItems = new ObservableCollection<MediaItem>(Items);

			mediums = new List<string>
			{
				"All",
				nameof(ItemType.Book),
				nameof(ItemType.Music),
				nameof(ItemType.Video)
			};

			selectedMedium = Mediums[0];
		}

		public ICommand AddEditCommand { get; set; }

		public void AddOrEditItem()
		{
			// Note this is temporary until
			// we use a real data source for items.
			const int startingItemCount = 3;
			var newItem = new MediaItem
			{
				Id = startingItemCount + additionalItemCount,
				Location = LocationType.InCollection,
				MediaType = ItemType.Music,
				MediumInfo = new Medium { Id = 1, MediaType = ItemType.Music, Name = "CD" },
				Name = $"CD {additionalItemCount}"
			};
			allItems.Add(newItem);
			Items.Add(newItem);
			additionalItemCount++;
		}

		public ICommand DeleteCommand { get; set; }

		private void DeleteItem()

		{

			allItems.Remove(SelectedMediaItem);

			Items.Remove(SelectedMediaItem);

		}

		private bool CanDeleteItem() => selectedMediaItem != null;



	}
}