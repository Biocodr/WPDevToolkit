﻿using System;

namespace WPDevToolkit.Selection
{
    public class SelectionItem<T> : BaseNotifyPropertyChanged, ISelectionItem<T>, IEquatable<SelectionItem<T>>
    {
        private T _value;
        private string _display;
        private bool _isSelected;

        public SelectionItem(string key)
            : this(key, default(T))
        { }

        public SelectionItem(string key, T value)
            : this(key, value, value.ToString())
        { }

        public SelectionItem(string key, T value, string display)
        {
            Key = key;
            Value = value;
            Display = display;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals(obj as SelectionItem<T>);
        }

        public bool Equals(SelectionItem<T> other)
        {
            return Key.Equals(other.Key);
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public string Key { get; private set; }

        public T Value
        {
            get { return _value; }
            set
            {
                if (_value == null || !_value.Equals(value))
                {
                    _value = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Display
        {
            get { return _display; }
            set
            {
                if (_display != value)
                {
                    _display = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
