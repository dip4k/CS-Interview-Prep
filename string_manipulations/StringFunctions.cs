using System.Linq;

public class StringFunctions {
  public string ReverseString (string str) {
    return "";
  }

  // public string RemoveDuplicateChars (string key) {
  //   // --- Removes duplicate chars using string concats. ---
  //   // Store encountered letters in this string.
  //   string table = "";

  //   // Store the result in this string.
  //   string result = "";

  //   // Loop over each character.
  //   foreach (char value in key) {
  //     // See if character is in the table.
  //     if (table.IndexOf (value) == -1) {
  //       // Append to the table and the result.
  //       table += value;
  //       result += value;
  //     }
  //   }
  //   return result;
  // }

  public string RemoveDuplicateChars (string key) {
    string result = new string (key.ToLower ().Distinct ().ToArray ());
    return result;
  }
}
