import com.novell.ldap.LDAPAttribute;
import com.novell.ldap.LDAPConnection;
import com.novell.ldap.LDAPException;
import com.novell.ldap.LDAPSearchResults;

public class LDAPTest {

    @SuppressWarnings("unchecked")
    public static void main(String[] args) {
        var ldapConnectionBuilder = new Connection.ConnectionBuilder("193.6.5.58",
                "ou=csop_HU,ou=ev2020,ou=meinfo,dc=maxcrc,dc=com", new String("H578").getBytes());
        LDAPConnection ldapConnection = new LDAPConnection();
        try {
            ldapConnection = ldapConnectionBuilder.build().getLdapConnection();
            System.out.println("Connected.");
        } catch (LDAPException e) {
            e.printStackTrace();
        }
        System.out.println("isConnected: " + ldapConnection.isConnected());
        System.out.println("isBound: " + ldapConnection.isBound());

        try {
            LDAPSearchResults searchResults = ldapConnection.search("ou=meinfo,dc=maxcrc,dc=com",
                    LDAPConnection.SCOPE_SUB, "objectclass=person", null, false);
            while (searchResults.hasMore()) {
                try {
                    var next = searchResults.next();
                    System.out.println(next.getDN());
                    var attributeSet = next.getAttributeSet();
                    attributeSet.stream().filter(a -> ((LDAPAttribute) a).getName().equals("sn"))
                            .forEach(a -> System.out.println("\t" + ((LDAPAttribute) a).getName() + "::"
                                    + ((LDAPAttribute) a).getStringValue()));
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
            ldapConnection.disconnect();
        } catch (LDAPException e) {
            e.printStackTrace();
        }

        System.out.println("After disconnect has been called:");
        System.out.println("isConnected: " + ldapConnection.isConnected());
        System.out.println("isBound: " + ldapConnection.isBound());
    }
}