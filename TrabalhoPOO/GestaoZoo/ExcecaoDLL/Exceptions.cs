using System;
using System.Runtime.ConstrainedExecution;

namespace ExcecaoDLL
{
    public class InvalidDataException : ApplicationException
    {
        public InvalidDataException() : base(string.Format("Dados inválidos"))
        {
            throw new InvalidDataException();
        }
        public InvalidDataException(string message) : base(string.Format("Dados inválidos; Mensagem: {0}", message)) 
        {
            throw new InvalidDataException(this.Message + " - " + message);
        }
        public InvalidDataException(string message, Exception inner) : base(string.Format("Dados inválidos; Mensagem: {0}", message), inner) 
        {
            throw new InvalidDataException(inner.Message+ " - " + message, inner);
        }
    }

    public class InvalidNameException : ApplicationException
    {
        public InvalidNameException() : base(string.Format("Nome inválido (a-z,A-Z)"))
        {
            throw new InvalidNameException();
        }
        public InvalidNameException(string name) : base(string.Format("Nome inválido: {0}; (a-z,A-Z)", name))
        {
            throw new InvalidNameException(this.Message + " - " + name);
        }
        public InvalidNameException(string name, Exception inner) : base(string.Format("Nome inválido: {0}; (a-z,A-Z)", name), inner)
        {
            throw new InvalidNameException(inner.Message + " - " + name, inner);
        }
    }
    public class InvalidDateException : ApplicationException
    {
        public InvalidDateException() : base(string.Format("Data inválida"))
        {
            throw new InvalidDateException();
        }
        public InvalidDateException(string date) : base(string.Format("Data inválida: {0}", date))
        {
            throw new InvalidDateException(this.Message + " - " + date);
        }
        public InvalidDateException(string date, Exception inner) : base(string.Format("Data inválida: {0}", date), inner)
        {
            throw new InvalidDateException(inner.Message + " - " + date, inner);
        }
    }
    public class InvalidNumberException : ApplicationException
    {
        public InvalidNumberException() : base(string.Format("Número inválido"))
        {
            throw new InvalidNumberException();
        }
        public InvalidNumberException(string number) : base(string.Format("Número inválido: {0}", number))
        {
            throw new InvalidNumberException(this.Message + " - " + number);
        }
        public InvalidNumberException(string number, Exception inner) : base(string.Format("Número inválido: {0}", number), inner)
        {
            throw new InvalidNumberException(inner.Message + " - " + number, inner);
        }
    }
    public class InvalidTypeException : ApplicationException
    {
        public InvalidTypeException() : base(string.Format("Tipo inválido"))
        {
            throw new InvalidTypeException();
        }
        public InvalidTypeException(string message) : base(string.Format("Tipo inválido; Mensagem: {0}", message))
        {
            throw new InvalidTypeException(this.Message + " - " + message);
        }
        public InvalidTypeException(string message, Exception inner) : base(string.Format("Tipo inválido; Mensagem: {0}", message), inner)
        {
            throw new InvalidTypeException(inner.Message + " - " + message, inner);
        }
    }
    public class InvalidSexException : ApplicationException
    {
        public InvalidSexException() : base(string.Format("Sexo inválido"))
        {
            throw new InvalidSexException();
        }
        public InvalidSexException(string sex) : base(string.Format("Sexo inválido: {0}", sex))
        {
            throw new InvalidSexException(this.Message + " - " + sex);
        }
        public InvalidSexException(string sex, Exception inner) : base(string.Format("Sexo inválido: {0}", sex), inner)
        {
            throw new InvalidSexException(inner.Message + " - " + sex, inner);
        }
    }
    public class NegativeNumberException : ApplicationException
    {
        public NegativeNumberException() : base(string.Format("Número não pode ser negativo, nem zero"))
        {
            throw new NegativeNumberException();
        }
        public NegativeNumberException(string number) : base(string.Format("Número não pode ser negativo, nem zero: {0}", number))
        {
            throw new NegativeNumberException(this.Message + " - " + number);
        }
        public NegativeNumberException(string number, Exception inner) : base(string.Format("Número não pode ser negativo, nem zero: {0}", number), inner)
        {
            throw new NegativeNumberException(inner.Message + " - " + number, inner);
        }
    }
    public class GreaterThanPreviousDateException : ApplicationException
    {
        public GreaterThanPreviousDateException() : base(string.Format("Data não pode ser maior do que a anterior"))
        {
            throw new GreaterThanPreviousDateException();
        }
        public GreaterThanPreviousDateException(string date1, string date2) : base(string.Format("Data não pode ser maior do que a anterior: {0} > {1}", date1, date2))
        { 
            throw new GreaterThanPreviousDateException(date1, date2);
        }
        public GreaterThanPreviousDateException(string date1, string date2, Exception inner) : base(string.Format("Data não pode ser maior do que a anterior: {0} > {1}", date1, date2), inner)
        {
            throw new GreaterThanPreviousDateException(inner.Message + " - " + date1 , date2, inner);
        }
    }
    public class InvalidIDException : ApplicationException
    {
        public InvalidIDException() : base(string.Format("ID inválido"))
        {
            throw new InvalidIDException();
        }
        public InvalidIDException(string id) : base(string.Format("ID inválido: {0}", id))
        {
            throw new InvalidIDException(this.Message + " - " + id);
        }
        public InvalidIDException(string id, Exception inner) : base(string.Format("ID inválido: {0}", id), inner)
        {
            throw new InvalidIDException(inner.Message + " - " + id, inner);
        }
    }
    public class AlreadyExistsException : ApplicationException
    {
        public AlreadyExistsException() : base(string.Format("O objeto já existe"))
        {
            throw new AlreadyExistsException();
        }
        public AlreadyExistsException(string id) : base(string.Format("O objeto {0} já existe", id))
        {
            throw new AlreadyExistsException(this.Message + " - " + id);
        }
        public AlreadyExistsException(string id, Exception inner) : base(string.Format("O objeto {0} já existe", id), inner)
        {
            throw new AlreadyExistsException(inner.Message + " - " + id, inner);
        }
    }
    public class InvalidStateException : ApplicationException
    {
        public InvalidStateException() : base(string.Format("Estado inválido"))
        {
            throw new InvalidStateException();
        }
        public InvalidStateException(string state) : base(string.Format("Estado inválido: {0}", state))
        {
            throw new InvalidStateException(this.Message + " - " + state);
        }
        public InvalidStateException(string state, Exception inner) : base(string.Format("Estado inválido: {0}", state), inner)
        {
            throw new InvalidStateException(inner.Message + " - " + state, inner);
        }
    }
    public class InvalidValueException : ApplicationException
    {
        public InvalidValueException() : base(string.Format("Valor inválido"))
        {
            throw new InvalidValueException();
        }
        public InvalidValueException(string value) : base(string.Format("Valor inválido: {0}", value))
        {
            throw new InvalidValueException(this.Message + " - " + value);
        }
        public InvalidValueException(string value, Exception inner) : base(string.Format("Valor inválido: {0}", value), inner)
        {
            throw new InvalidValueException(inner.Message + " - " + value, inner);
        }
    }
    public class InvalidClassException : ApplicationException
    {
        public InvalidClassException() : base(string.Format("Classe inválida"))
        {
            throw new InvalidClassException();
        }
        public InvalidClassException(string classe) : base(string.Format("Classe inválida: {0}", classe))
        {
            throw new InvalidClassException(this.Message + " - " + classe);
        }
        public InvalidClassException(string classe, Exception inner) : base(string.Format("Classe inválida: {0}", classe), inner)
        {
            throw new InvalidClassException(inner.Message + " - " + classe, inner);
        }
    }
    public class InvalidDietException : ApplicationException
    {
        public InvalidDietException() : base(string.Format("Dieta inválida"))
        {
            throw new InvalidDietException();
        }
        public InvalidDietException(string diet) : base(string.Format("Dieta inválida: {0}", diet))
        {
            throw new InvalidDietException(this.Message + " - " + diet);
        }
        public InvalidDietException(string diet, Exception inner) : base(string.Format("Dieta inválida: {0}", diet), inner)
        {
            throw new InvalidDietException(inner.Message + " - " + diet, inner);
        }
    }
    public class DoesNotExistException : ApplicationException
    {
        public DoesNotExistException() : base(string.Format("O objeto não existe"))
        {
            throw new DoesNotExistException();
        }
        public DoesNotExistException(string id) : base(string.Format("O objeto {0} não existe", id))
        {
            throw new DoesNotExistException(this.Message + " - " + id);
        }
        public DoesNotExistException(string id, Exception inner) : base(string.Format("O objeto {0} não existe", id), inner)
        {
            throw new DoesNotExistException(inner.Message + " - " + id, inner);
        }
    }
    public class InvalidTextException : ApplicationException
    {
        public InvalidTextException() : base(string.Format("Texto inválido; (a-z,A-Z)"))
        {
            throw new InvalidTextException();
        }
        public InvalidTextException(string text) : base(string.Format("Texto inválido: {0}; (a-z,A-Z)", text))
        {
            throw new InvalidTextException(this.Message + " - " + text);
        }
        public InvalidTextException(string text, Exception inner) : base(string.Format("Texto inválido: {0}; (a-z,A-Z)", text), inner)
        {
            throw new InvalidTextException(inner.Message + " - " + text, inner);
        }
    }
    public class InvalidEmailException : ApplicationException
    {
        public InvalidEmailException() : base(string.Format("Email inválido"))
        {
            throw new InvalidEmailException();
        }
        public InvalidEmailException(string email) : base(string.Format("Email inválido: {0}", email))
        {
            throw new InvalidEmailException(this.Message + " - " + email);
        }
        public InvalidEmailException(string email, Exception inner) : base(string.Format("Email inválido: {0}", email), inner)
        {
            throw new InvalidEmailException(inner.Message + " - " + email, inner);
        }
    }
    public class InvalidPhoneException : ApplicationException
    {
        public InvalidPhoneException() : base(string.Format("Telefone inválido"))
        {
            throw new InvalidPhoneException();
        }
        public InvalidPhoneException(string phone) : base(string.Format("Telefone inválido: {0}", phone))
        {
            throw new InvalidPhoneException(this.Message + " - " + phone);
        }
        public InvalidPhoneException(string phone, Exception inner) : base(string.Format("Telefone inválido: {0}", phone), inner)
        {
            throw new InvalidPhoneException(inner.Message + " - " + phone, inner);
        }
    }
    public class InvalidRoleException : ApplicationException
    {
        public InvalidRoleException() : base(string.Format("Cargo inválido"))
        {
            throw new InvalidRoleException();
        }
        public InvalidRoleException(string role) : base(string.Format("Cargo inválido: {0}", role))
        {
            throw new InvalidRoleException(this.Message + " - " + role);
        }
        public InvalidRoleException(string role, Exception inner) : base(string.Format("Cargo inválido: {0}", role), inner)
        {
            throw new InvalidRoleException(inner.Message + " - " + role, inner);
        }
    }
    public class GreaterThanMaxCapacityException : ApplicationException
    {
        public GreaterThanMaxCapacityException() : base(string.Format("Lotação não pode ser maior do que a lotação total"))
        {
            throw new GreaterThanMaxCapacityException();
        }
        public GreaterThanMaxCapacityException(string capacity, string maxCapacity) : base(string.Format("Lotação não pode ser maior do que a lotação total: {0} > {1}", capacity, maxCapacity))
        {
            throw new GreaterThanMaxCapacityException(capacity, maxCapacity);
        }
        public GreaterThanMaxCapacityException(string capacity, string MaxCapacity, Exception inner) : base(string.Format("Lotação não pode ser maior do que a lotação total: {0} > {1}", capacity, MaxCapacity), inner)
        {
            throw new GreaterThanMaxCapacityException(inner.Message + " - " + capacity, MaxCapacity, inner);
        }
    }
    public class LessThanZeroNumberException : ApplicationException
    {
        public LessThanZeroNumberException() : base(string.Format("Número não pode ser negativo, mas pode ser zero"))
        {
            throw new LessThanZeroNumberException();
        }
        public LessThanZeroNumberException(string number) : base(string.Format("Número não pode ser negativo, mas pode ser zero: {0}", number))
        {
            throw new LessThanZeroNumberException(this.Message + " - " + number);
        }
        public LessThanZeroNumberException(string number, Exception inner) : base(string.Format("Número não pode ser negativo, mas pode ser zero: {0}", number), inner)
        {
            throw new LessThanZeroNumberException(inner.Message + " - " + number, inner);
        }
    }
    public class OutOfExpirationDateException : ApplicationException
    {
        public OutOfExpirationDateException() : base(string.Format("Data de validade expirada"))
        {
            throw new OutOfExpirationDateException();
        }
        public OutOfExpirationDateException(string date) : base(string.Format("Data de validade expirada: {0}", date))
        {
            throw new OutOfExpirationDateException(this.Message + " - " + date);
        }
        public OutOfExpirationDateException(string date, Exception inner) : base(string.Format("Data de validade expirada: {0}", date), inner)
        {
            throw new OutOfExpirationDateException(inner.Message + " - " + date, inner);
        }
    }
}
